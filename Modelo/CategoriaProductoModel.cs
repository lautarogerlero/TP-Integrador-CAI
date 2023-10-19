using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CategoriaProductoModel
    {
        public int _id;
        public string _descripcion;

        public int Id { get => _id; set => _id = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        public CategoriaProductoModel(int id, string descripcion)
        {
            // Las que tienen mayuscula son las que tienen setter
            Id = id;
            Descripcion = descripcion;
        }
    }
}