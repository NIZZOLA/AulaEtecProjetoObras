using Microsoft.EntityFrameworkCore;
using Obra.Domain.Models;
using Obra.Infra.Data;

namespace Obra.MVC.Data
{
    public class ObraMVCContext : ObraDataContext
    {
        public ObraMVCContext(DbContextOptions<ObraDataContext> options)
            : base(options)
        {
        }
    }
}
