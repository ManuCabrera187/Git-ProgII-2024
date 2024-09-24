using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _24_09.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public bool EstaActivo { get; set; }
        [ForeignKey("Rol")]
        public int IdRol { get; set; }
        public Rol Rol { get; set; }
    }
}
