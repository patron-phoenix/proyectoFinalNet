namespace Proyecto_final_ASP.NET.Models
{
    public class ProductoModel
    {
        private List<Producto> productos;
        public ProductoModel() {
            productos = new List<Producto>()
            {
                new Producto
                {
                    Id="prod001",
                    Nombre="Atun",
                    Precio=12.5,
                    Foto="atun.png"
                },
                new Producto
                {
                    Id="prod002",
                    Nombre="Carne de Res",
                    Precio=35.5,
                    Foto="carneRes.png"
                },

                 new Producto
                {
                    Id="prod003",
                    Nombre="Pescado Trucha",
                    Precio=15,
                    Foto="pescado.png"
                },
                 new Producto
                {
                    Id="prod004",
                    Nombre="Pollo",
                    Precio=40.5,
                    Foto="pollo.png"
                },
                new Producto
                {
                    Id="prod005",
                    Nombre="Queso",
                    Precio=17.5,
                    Foto="queso.png"
                },
                new Producto
                {
                    Id="prod006",
                    Nombre="Yogurt",
                    Precio=17.5,
                    Foto="yogurt.png"
                }
            };
        }

        public List<Producto> getTodo()
        {
            return productos;
        }
        public Producto getById(string id)
        {
            return productos.Single(p=>p.Id==id);
        }
    }
}
