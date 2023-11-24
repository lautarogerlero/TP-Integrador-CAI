using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class VentaModel
    {
        private string _idCliente;
        private string _idUsuario;
        private string _idProducto;
        private int _cantidad;

        public string IdCliente { get => _idCliente; set => _idCliente = value; }
        public string IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string IdProducto { get => _idProducto; set => _idProducto = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        
    // Constructor que recibe valores iniciales para idCliente, idUsuario, idProducto y cantidad
        public VentaModel(string idCliente, string idUsuario, string idProducto, int cantidad)
        {
        // Inicializar las propiedades con los valores proporcionados
        // Las que tienen mayuscula son las que tienen setter
            IdCliente = idCliente;
            IdUsuario = idUsuario;
            IdProducto = idProducto;
            Cantidad = cantidad;
        }
    }
}

