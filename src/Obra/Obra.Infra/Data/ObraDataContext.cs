using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Obra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Infra.Data
{
    public class ObraDataContext : IdentityDbContext<IdentityUser>
    {
        public ObraDataContext(DbContextOptions<ObraDataContext> options)
            : base(options)
        {
        }

        public DbSet<TipoDePagamentoModel> TiposDePagamentos { get; set; } = default!;

        public DbSet<TipoDeDespesaReceitaModel>? TiposDeDespesaReceitas { get; set; }

        public DbSet<ClienteFornecedorModel>? ClientesFornecedores { get; set; }

        public DbSet<EmpreendimentoModel>? Empreendimentos { get; set; }

        public DbSet<ContaModel>? Contas { get; set; }

        public DbSet<FotoEmpreendimentoModel>? FotosEmpreendimentos { get; set; }
        public DbSet<UsuarioModel>? Usuarios { get; set; }
    }
}