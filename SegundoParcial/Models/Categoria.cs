using System.ComponentModel.DataAnnotations;

namespace SegundoParcial.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }
        [Required, MaxLength(200)]
        public string Descripcion {  get; set; }

    }
}
