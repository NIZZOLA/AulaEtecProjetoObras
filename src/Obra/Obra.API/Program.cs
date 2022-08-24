using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obra.API.Contacts.Requests;
using Obra.API.Contracts.Response;
using Obra.API.Extensions;
using Obra.Domain.Models;
using Obra.Infra.Data;
using Obra.API;

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

var configAutomapper = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<ClienteFornecedorModel, ClienteResponseModel>();
    cfg.CreateMap<EmpreendimentoModel, EmpreendimentoResponseModel>();
});
IMapper mapper = configAutomapper.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/clientes", async (ObraDataContext _context, IMapper _mapper) =>
{
    var clientes = await _context.ClientesFornecedores.ToListAsync();
    var response = _mapper.Map<ICollection<ClienteResponseModel>>(clientes);

    return Results.Ok(response);
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

app.MapGet("/empreendimentos", async (ObraDataContext _context, IMapper _mapper) =>
{
var empreendimentos = await _context.Empreendimentos.Include(a =>a.Cliente)
    .OrderBy(a => a.Nome).ToListAsync();

    var results = _mapper.Map<ICollection<EmpreendimentoResponseModel>>(empreendimentos);
    return Results.Ok(results);
});

app.MapGet("/empreendimentos/{id}", async (ObraDataContext _context, Guid? id) =>
{
    if (!id.HasValue)
        return Results.BadRequest();

    var empreendimento = await _context.Empreendimentos.Include(a => a.Cliente).Where(a => a.Id == id.Value).FirstOrDefaultAsync();
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
    var obj = conta.ToContaModel();

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