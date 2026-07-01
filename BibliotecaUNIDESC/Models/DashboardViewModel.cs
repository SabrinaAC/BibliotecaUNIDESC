using System.Collections.Generic;

namespace BibliotecaUNIDESC.Models
{
    public class DashboardViewModel
    {
        public int TotalLivros { get; set; }

        public List<Livro> UltimosLivros { get; set; } = new();
    }
}