using Microsoft.AspNetCore.Mvc;

namespace SistemasWeb.Areas.Principal.Controllers
{
    public class PrincipalController : Controller
    {
        [Area("Principal")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
