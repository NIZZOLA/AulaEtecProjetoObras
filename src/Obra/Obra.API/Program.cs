using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddDbContext<ObraMVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ObraMVCContext") ?? throw new InvalidOperationException("Connection string 'ObraMVCContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/clientes", async (ObraMVCContext _context) =>
{
    var clientes = await _context.ClienteFornecedorModel.ToListAsync();
    return Results.Ok(clientes);
})
.WithName("GetClientes");

app.MapGet("/empreendimentos", async (ObraMVCContext _context) =>
{
    var empreendimentos = await _context.EmpreendimentoModel.ToListAsync();
    return Results.Ok(empreendimentos);
})
.WithName("GetEmpreendimentos");


app.MapGet("/empreendimentos/{id}", async (ObraMVCContext _context, Guid? id) =>
{
    if (!id.HasValue)
        return Results.BadRequest();

    var empreendimento = await _context.EmpreendimentoModel.Where(a => a.Id == id.Value).FirstOrDefaultAsync();
    return Results.Ok(empreendimento);
})
.WithName("GetEmpreendimentoPorId");

app.MapGet("/empreendimentos/cliente/{idCliente}", async (ObraMVCContext _context, Guid? idCliente) =>
{
    if (!idCliente.HasValue)
        return Results.BadRequest();

    var tipos = await _context.EmpreendimentoModel.Where(a=>a.ClienteId == idCliente.Value).ToListAsync();
    return Results.Ok(tipos);
})
.WithName("GetEmpreendimentosPorClientes");



app.MapGet("/tipodedespesasereceitas",async (ObraMVCContext _context) =>
{
    var tipos = await _context.TipoDeDespesaReceitaModel.ToListAsync();
    return Results.Ok(tipos);
})
.WithName("GetTipoDeDespesasEReceitas");



app.Run();

