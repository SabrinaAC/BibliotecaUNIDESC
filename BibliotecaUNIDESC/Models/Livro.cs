using System.ComponentModel.DataAnnotations;

namespace BibliotecaUNIDESC.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Categoria { get; set; }

        public int AnoPublicacao { get; set; }

        public int Quantidade { get; set; }
    }
}