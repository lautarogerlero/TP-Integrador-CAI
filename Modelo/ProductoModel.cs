using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ProductoModel
    {
        private int _idCategoria;
        private string _idUsuario;
        private string _idProveedor;
        private string _nombre;
        private int _precio;
        private int _stock;

        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string IdProveedor { get => _idProveedor; set => _idProveedor = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Precio { get => _precio; set=> _precio = value; }
        public int Stock { get => _stock; set => _stock = value; }

        public ProductoModel(int idCategoria, string idUsuario, string idProveedor, string nombre, int precio, int stock)
        {
            // Las que tienen mayuscula son las que tienen setter
            IdCategoria = idCategoria;
            IdUsuario = idUsuario;
            IdProveedor = idProveedor;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }
    }
}
