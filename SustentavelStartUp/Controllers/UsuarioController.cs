using Microsoft.AspNetCore.Mvc;

namespace SustentavelStartUp.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
