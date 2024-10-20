using System.ComponentModel.DataAnnotations;

namespace Gestion_Biblioteca.Models
{
    public class Libro
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        public int AutorID { get; set; }
        // Relación con el autor.
        public virtual Autor? Autor { get; set; }
    }
}
