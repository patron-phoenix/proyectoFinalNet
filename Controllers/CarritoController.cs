using Microsoft.AspNetCore.Mvc;
using Proyecto_final_ASP.NET.Herramientas;
using Proyecto_final_ASP.NET.Models;

namespace Proyecto_final_ASP.NET.Controllers
{
    [Route("Carrito")]
    public class CarritoController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            List<Item> carrito = ConversorParaSesion.GetObjetoDeJson<List<Item>>(HttpContext.Session, "carrito");
            ViewBag.carrito = carrito;
            if (carrito == null)
            {
                carrito = new List<Item>();
            }
            ViewBag.total=carrito.Sum(item=> item.producto.Precio*item.cantidad);
            return View();
        }


        [Route("Agregar/{id}")]
        public IActionResult Agregar(string id)
        {
            ProductoModel productoModel=new ProductoModel();
            //queremos agregar un producto al carrito
            if (ConversorParaSesion.GetObjetoDeJson<List<Item>>(HttpContext.Session, "carrito")==null) 
            {
                List<Item> carrito = new List<Item>();
                carrito.Add(new Item { producto = productoModel.getById(id), cantidad = 1 });
                ConversorParaSesion.SetObjetoAJson(HttpContext.Session,"carrito",carrito);
            }
            else
            {
                List<Item> carrito = ConversorParaSesion.GetObjetoDeJson<List<Item>>(HttpContext.Session, "carrito");
                int indice = existe(id);
                if (indice!=-1)
                {
                    carrito[indice].cantidad++;
                }
                else
                {
                    carrito.Add(new Item { producto = productoModel.getById(id), cantidad = 1 });
                }
                ConversorParaSesion.SetObjetoAJson(HttpContext.Session, "carrito", carrito);
            }

            return RedirectToAction("Index");
        }

        [NonAction]
        private int existe(string id)
        {
           List<Item> carrito = ConversorParaSesion.GetObjetoDeJson<List<Item>>(HttpContext.Session, "carrito");
            for (int i = 0; i< carrito.Count;i++)
            {
                if (carrito[i].producto.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        [Route("Eliminar/{id}")]
        public IActionResult Eliminar(string id)
        {
            List<Item> carrito = ConversorParaSesion.GetObjetoDeJson<List<Item>>(HttpContext.Session, "carrito");
            ViewBag.carrito = carrito;
            int indice = existe(id);
            carrito.RemoveAt(indice);
            ConversorParaSesion.SetObjetoAJson(HttpContext.Session,"carrito",carrito);
            return RedirectToAction("Index");
        }

        [Route("Pago")]
        public IActionResult Pago()
        {
            List<Item> carrito = ConversorParaSesion.GetObjetoDeJson<List<Item>>(HttpContext.Session, "carrito");
            ViewBag.carrito = carrito;

            ConversorParaSesion.SetObjetoAJson(HttpContext.Session, "carrito", new List<Item>());
            ViewBag.total = carrito.Sum(item => item.producto.Precio * item.cantidad);
            return View();
        }
    }
}
