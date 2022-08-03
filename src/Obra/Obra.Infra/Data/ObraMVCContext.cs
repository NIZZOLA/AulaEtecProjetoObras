using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Infra.Data
{
    public class ObraMVCContext : DbContext
    {
        public ObraMVCContext(DbContextOptions<ObraMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Obra.Domain.Models.TipoDePagamentoModel> TipoDePagamentoModel { get; set; } = default!;

        public DbSet<Obra.Domain.Models.TipoDeDespesaReceitaModel>? TipoDeDespesaReceitaModel { get; set; }

        public DbSet<Obra.Domain.Models.ClienteFornecedorModel>? ClienteFornecedorModel { get; set; }

        public DbSet<Obra.Domain.Models.EmpreendimentoModel>? EmpreendimentoModel { get; set; }

        public DbSet<Obra.Domain.Models.ContaModel>? ContaModel { get; set; }

        public DbSet<Obra.Domain.Models.FotoEmpreendimentoModel>? FotoEmpreendimentoModel { get; set; }
    }
}
