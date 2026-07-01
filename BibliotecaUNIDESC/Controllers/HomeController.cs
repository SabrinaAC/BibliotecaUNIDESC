using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BibliotecaUNIDESC.Models;
using BibliotecaUNIDESC.Data;
using BibliotecaUNIDESC.ViewModels;

namespace BibliotecaUNIDESC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BibliotecaContext _context;

        public HomeController(ILogger<HomeController> logger, BibliotecaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel
            {
                TotalLivros = _context.Livros.Count(),

                LivrosDisponiveis = _context.Livros.Sum(l => l.Quantidade),

                TotalUsuarios = 0,

                TotalEmprestimos = 0,

                UltimosLivros = _context.Livros
                    .OrderByDescending(l => l.Id)
                    .Take(5)
                    .ToList()
            };

            return View(dashboard);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}