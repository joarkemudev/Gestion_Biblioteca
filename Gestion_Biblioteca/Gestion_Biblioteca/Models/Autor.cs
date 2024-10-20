using System.ComponentModel.DataAnnotations;

namespace Gestion_Biblioteca.Models
{
    public class Autor
    {
        public int AutorID { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        // Inicializa la colección de libros en el constructor.
        public virtual ICollection<Libro> Libros { get; set; }

        public Autor()
        {
            Libros = new HashSet<Libro>();
        }
    }
}
