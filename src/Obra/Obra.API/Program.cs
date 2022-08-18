using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obra.API.Contacts.Requests;
using Obra.Domain.Models;
using Obra.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:8100")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ObraDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ObraMVCContext") ?? throw new InvalidOperationException("Connection string 'ObraMVCContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/clientes", async (ObraDataContext _context) =>
{
    var clientes = await _context.ClientesFornecedores.ToListAsync();
    return Results.Ok(clientes);
});

app.MapGet("/clientes/{idCliente}", async (ObraDataContext _context, Guid idCliente) =>
{
    var clientes = await _context.ClientesFornecedores
                            .Where(m => m.Id == idCliente)
                            .FirstOrDefaultAsync();
    if (clientes == null)
        return Results.NotFound();

    return Results.Ok(clientes);
});

app.MapGet("/empreendimentos", async (ObraDataContext _context) =>
{
    var empreendimentos = await _context.Empreendimentos.ToListAsync();
    return Results.Ok(empreendimentos);
});

app.MapGet("/empreendimentos/{id}", async (ObraDataContext _context, Guid? id) =>
{
    if (!id.HasValue)
        return Results.BadRequest();

    var empreendimento = await _context.Empreendimentos.Where(a => a.Id == id.Value).FirstOrDefaultAsync();
    return Results.Ok(empreendimento);
});

app.MapGet("/empreendimentos/cliente/{idCliente}", async (ObraDataContext _context, Guid? idCliente) =>
{
    if (!idCliente.HasValue)
        return Results.BadRequest();

    var empreendimentos = await _context.Empreendimentos
            .Where(a=>a.ClienteId == idCliente.Value).ToListAsync();
    return Results.Ok(empreendimentos);
});


app.MapGet("/contas/{idConta}", async (ObraDataContext _context, Guid? idConta) =>
{
    if (!idConta.HasValue)
        return Results.BadRequest();
    var contas = await _context.Contas
                        .Where(a => a.Id == idConta.Value).ToListAsync();
    return Results.Ok(contas);
});

app.MapGet("/contas/empreendimento/{idEmpreendimento}", async (ObraDataContext _context, Guid? idEmpreendimento) =>
{
    if (!idEmpreendimento.HasValue)
        return Results.BadRequest();
    var contas = await _context.Contas
                        .Where(a => a.EmpreendimentoId == idEmpreendimento.Value).ToListAsync();
    return Results.Ok(contas);
});


app.MapPost("/contas", async (ObraDataContext _context, [FromBody] ContaRequestModel conta) =>
{
    var obj = new ContaModel()
    {
        DataDoPagamento = conta.DataDoPagamento,
        DataCriacao = DateTime.Now,
        DataDaCompra = conta.DataDaCompra,
        EmpreendimentoId = conta.EmpreendimentoId,
        NumeroDoDocumento = conta.NumeroDoDocumento,
        Observacoes = conta.Observacoes,
        TipoDeDespesaId = conta.TipoDeDespesaId,
        TipoDePagamentoId = conta.TipoDePagamentoId,
        Valor = conta.Valor,
        ValorPago = conta.ValorPago,
        Vencimento = conta.Vencimento
    };
    _context.Add(obj);
    await _context.SaveChangesAsync();

    return Results.Ok(obj);
});

app.MapGet("/tipodedespesasereceitas",async (ObraDataContext _context) =>
{
    var tipos = await _context.TiposDeDespesaReceitas.ToListAsync();
    return Results.Ok(tipos);
});

app.MapGet("/formadepagamento", async (ObraDataContext _context) =>
{
    var tipos = await _context.TiposDePagamentos.ToListAsync();
    return Results.Ok(tipos);
});

app.Run();