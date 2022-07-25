using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SistemasWeb.Areas.Categorias.Models;
using SistemasWeb.Controllers;
using SistemasWeb.Data;
using SistemasWeb.Models;
using SistemasWeb.Library;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace SistemasWeb.Areas.Categorias.Controllers
{
    [Area("Categorias")]
    [Authorize]
    public class CategoriasController : Controller
    {
        private TCategoria _categoria;
        private LCategorias _lcategoria;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPaginador<TCategoria> models;
        public CategoriasController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _lcategoria = new LCategorias(context);
        }
        public IActionResult Categoria()
        {
            if (_signInManager.IsSignedIn(User))
            {
                models = new DataPaginador<TCategoria>
                {
                    Input = new TCategoria()
                };
                return View(models);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        [HttpPost]
        public String GetCategorias(DataPaginador<TCategoria> model)
        {
            if (model.Input.Nombre != null && model.Input.Descripcion != null)
            {
                var data = _lcategoria.RegistrarCategoria(model.Input);
                return JsonConvert.SerializeObject(data);
            }
            else
            {
                return "Llene los campos requeridos";
            }
        }
    }
}
