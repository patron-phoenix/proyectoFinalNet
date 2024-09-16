using Microsoft.AspNetCore.Mvc;
using Proyecto_final_ASP.NET.Models;

namespace Proyecto_final_ASP.NET.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            //definir lista de productos
            //modelo ProductoModel
            var productoModelo= new ProductoModel();
            //viewgbag
            ViewBag.productos=productoModelo.getTodo();
            return View();
        }
    }
}
