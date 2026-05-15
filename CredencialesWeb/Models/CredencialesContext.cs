using Microsoft.EntityFrameworkCore;

namespace CredencialesWeb.Models
{
    public class CredencialesContext : DbContext
    {
        public DbSet<Credenciales> Credenciales { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<SitiosWeb> SitiosWeb { get; set; }
        public DbSet<Protocolo> Protocolo { get; set; }

        public CredencialesContext(DbContextOptions<CredencialesContext> options) : base(options)
        {
        }
    }
}
