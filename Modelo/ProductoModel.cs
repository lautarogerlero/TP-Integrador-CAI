using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ProductoModel
    {
        private int _id;
        private string _descripcion;
        private int _stock;

        public int Id { get => _id; set => _id = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int Stock { get => _stock; set => _stock = value; }

        public ProductoModel(int id, string descripcion, int stock)
        {
            // Las que tienen mayuscula son las que tienen setter
            Id = id;
            Descripcion = descripcion;
            Stock = stock;
        }
    }
}