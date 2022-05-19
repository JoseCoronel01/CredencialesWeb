using Microsoft.EntityFrameworkCore;

namespace CredencialesWeb.Models
{
    public class CredencialesContext : DbContext
    {
        public DbSet<Credenciales> Credenciales { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<SitiosWeb> SitiosWeb { get; set; }
        public DbSet<Protocolo> Protocolo { get; set; }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public CredencialesContext(string? cadenaConexion = null, DbContextOptionsBuilder<CredencialesContext> opt)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            
        }
    }
}
