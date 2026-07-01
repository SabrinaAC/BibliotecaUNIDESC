using Microsoft.AspNetCore.Mvc;

namespace BibliotecaUNIDESC.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}