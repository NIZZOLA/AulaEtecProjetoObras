using Microsoft.EntityFrameworkCore;
using Obra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Infra.Data
{
    public class ObraDataContext : DbContext
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

        private void ApplyBaseTracking()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified ));

            foreach (var entityEntry in entries)
            {
                ((BaseModel)entityEntry.Entity).DataAlteracao = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseModel)entityEntry.Entity).DataCriacao = DateTime.Now;
                }
            }
        }

        public override int SaveChanges()
        {
            this.ApplyBaseTracking();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ApplyBaseTracking();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}