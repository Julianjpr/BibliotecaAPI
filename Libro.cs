using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = null!;

        [Required]
        public string Autor { get; set; } = null!;

        public int AnioPublicacion { get; set; }

        public string Genero { get; set; } = null!;

        public int NumeroPaginas { get; set; }

        public decimal Precio { get; set; }

        public bool Disponible { get; set; }
    }
}
