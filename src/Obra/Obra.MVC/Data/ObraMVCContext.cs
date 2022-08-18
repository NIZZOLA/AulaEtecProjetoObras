using Microsoft.EntityFrameworkCore;
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
