using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SegundoParcial.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        [Required, MaxLength(300)]
        public string RazonSocial { get; set; }
        [Required, MaxLength(100)]
        public string Contacto { get; set; }
    }
}

