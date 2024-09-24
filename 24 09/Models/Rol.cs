using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _24_09.Models
{
    public class Rol
    {
        [Key]
        [Column("id_rol")]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public ICollection<Usuario> Usuarios=new List<Usuario>();
    }
}
