using System.ComponentModel.DataAnnotations;

namespace CredencialesWeb.Models
{
    public class Credenciales
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string? Empresa { get; set; }
        [StringLength(50)]
        public string? Clave { get; set; }
        [StringLength(50)]
        public string? Usuario { get; set; }
        [StringLength(80)]
        public string? Producto { get; set; }
        public byte? Baja { get; set; }

        public Credenciales()
        {
            this.Empresa = "PRUEBA";
            this.Clave = "PRUEBA";
            this.Usuario = "PRUEBA";
            this.Producto = "PRUEBA";
            this.Baja = 1;
        }
    }
}
