using Microsoft.AspNetCore.Mvc;

namespace SistemasWeb.Areas.Cursos.Controllers
{
    [Area("Cursos")]
    public class CursosController : Controller
    {
        public IActionResult Cursos()
        {
            return View();
        }
    }
}
