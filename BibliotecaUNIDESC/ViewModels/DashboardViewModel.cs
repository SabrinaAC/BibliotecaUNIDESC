using BibliotecaUNIDESC.Models;

namespace BibliotecaUNIDESC.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalLivros { get; set; }

        public int LivrosDisponiveis { get; set; }

        public int TotalUsuarios { get; set; }

        public int TotalEmprestimos { get; set; }

        public List<Livro> UltimosLivros { get; set; } = new();
    }
}