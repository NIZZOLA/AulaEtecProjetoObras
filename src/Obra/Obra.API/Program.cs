using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obra.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

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


app.MapGet("/tipodedespesasereceitas",async (ObraMVCContext _context) =>
{
    var tipos = await _context.TipoDeDespesaReceitaModel.ToListAsync();
    return Results.Ok(tipos);
})
.WithName("GetTipoDeDespesasEReceitas");

app.MapGet("/tipodedespesaereceitas/{id}", async (ObraMVCContext _context, [FromRoute] Guid? id) =>
{
    if (id == null)
        return Results.BadRequest();

    var tipoDeDespesaReceitaModel = await _context.TipoDeDespesaReceitaModel
                .FirstOrDefaultAsync(m => m.Id == id.Value);

    if (tipoDeDespesaReceitaModel == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(tipoDeDespesaReceitaModel);

}).WithName("GetTipo");


app.Run();

