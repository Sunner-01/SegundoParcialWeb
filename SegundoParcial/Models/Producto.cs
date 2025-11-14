using System.ComponentModel.DataAnnotations;

namespace SegundoParcial.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Nombre { get; set; }
        public string DescripcionCorta { get; set; }
        [Required]
        public float Precio { get; set; }
        [Required]
        public int Stock { get; set; }

        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
    }
}
