using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obra.API.Contacts.Requests;
using Obra.API.Contracts.Requests;
using Obra.API.Contracts.Response;
using Obra.API.Extensions;
using Obra.Domain.Models;
using Obra.Infra.Data;

namespace Obra.API
{
    public static class EndpointsConfiguration
    {
        public static void AddEndpoints( this WebApplication app )
        {
            app.MapGet("/clientes", async (ObraDataContext _context, IMapper _mapper) =>
            {
                var clientes = await _context.ClientesFornecedores.ToListAsync();
                var response = _mapper.Map<ICollection<ClienteResponseModel>>(clientes);

                return Results.Ok(response);
            }).RequireAuthorization("Administrador");

            app.MapGet("/clientes/{idCliente}", async (ObraDataContext _context, Guid idCliente) =>
            {
                var clientes = await _context.ClientesFornecedores
                                        .Where(m => m.Id == idCliente)
                                        .FirstOrDefaultAsync();
                if (clientes == null)
                    return Results.NotFound();

                return Results.Ok(clientes);
            }).RequireAuthorization();

            app.MapGet("/empreendimentos", async (ObraDataContext _context, IMapper _mapper) =>
            {
                var empreendimentos = await _context.Empreendimentos.Include(a => a.Cliente)
                    .OrderBy(a => a.Nome).ToListAsync();

                var results = _mapper.Map<ICollection<EmpreendimentoResponseModel>>(empreendimentos);
                return Results.Ok(results);
            });

            app.MapGet("/empreendimento/{id}", async (ObraDataContext _context, IMapper _mapper, Guid? id) =>
            {
                if (!id.HasValue)
                    return Results.BadRequest();

                var empreendimento = await _context.Empreendimentos
                                                    .Include(a => a.Cliente)
                                                    .Include(a => a.Fotos)
                                                    .Include(a => a.Contas)
                                                    .Where(a => a.Id == id.Value).FirstOrDefaultAsync();

                var resposta = _mapper.Map<EmpreendimentoResponseModel>(empreendimento);

                return Results.Ok(resposta);
            });

            app.MapGet("/empreendimentos/cliente/{idCliente}", async (ObraDataContext _context, Guid? idCliente) =>
            {
                if (!idCliente.HasValue)
                    return Results.BadRequest();

                var empreendimentos = await _context.Empreendimentos
                        .Where(a => a.ClienteId == idCliente.Value).ToListAsync();
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

            app.MapGet("/fotos/{idFoto}", async (ObraDataContext _context, Guid? idFoto) =>
            {
                if (!idFoto.HasValue)
                    return Results.BadRequest();
                var contas = await _context.FotosEmpreendimentos
                                    .Where(a => a.Id == idFoto.Value).ToListAsync();
                return Results.Ok(contas);
            });

            app.MapGet("/fotos/empreendimento/{idEmpreendimento}", async (ObraDataContext _context, Guid? idEmpreendimento) =>
            {
                if (!idEmpreendimento.HasValue)
                    return Results.BadRequest();
                var contas = await _context.FotosEmpreendimentos
                                    .Where(a => a.EmpreendimentoId == idEmpreendimento.Value).ToListAsync();
                return Results.Ok(contas);
            });

            app.MapPost("/fotos", async (ObraDataContext _context, HttpRequest request) =>
            {
                if (! request.Form.Files.Any() )
                    return Results.BadRequest("Arquivo enviado inválido");

                //TODO validar se é imagem também

                var obj = new FotoEmpreendimentoModel()
                {
                    EmpreendimentoId = Guid.Parse( request.Form["empreendimentoId"].ToString()),
                    Descricao = request.Form["descricao"],
                    Id = Guid.NewGuid()
                };

                try
                {
                    var arquivo = request.Form.Files[0];
                    string path = ".\\imagens";
                    string filename = path + "\\" + Guid.NewGuid().ToString() + arquivo.FileName;
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    using(FileStream fileStream = System.IO.File.Create(filename))
                    {
                        await arquivo.CopyToAsync(fileStream);
                        fileStream.Flush();
                        obj.NomeDoArquivo = System.IO.Path.GetFileName(filename);
                    }
                }
                catch (Exception error)
                {
                    throw;
                }

                _context.Add(obj);
                await _context.SaveChangesAsync();

                return Results.Ok(obj);
            });

            app.MapGet("/tipodedespesasereceitas", async (ObraDataContext _context) =>
            {
                var tipos = await _context.TiposDeDespesaReceitas.ToListAsync();
                return Results.Ok(tipos);
            });

            app.MapGet("/formadepagamento", async (ObraDataContext _context) =>
            {
                var tipos = await _context.TiposDePagamentos.ToListAsync();
                return Results.Ok(tipos);
            });

            app.MapPost("login", async([FromServices] ObraDataContext _context, [FromBody] UsuarioRequestModel model) =>
            {
                var user = _context.Usuarios.Where(a => a.Username == model.Username && a.Password == model.Password).FirstOrDefault();

                if (user == null)
                    return Results.NotFound(new { message = "Usuário ou senha inválidos !" });

                var token = TokenService.GenerateToken(user);

                return Results.Ok(new
                {
                    user = new { username = user.Username, role = user.Perfil.ToString() },
                    token = token
                });
            });
        }
    }
}
