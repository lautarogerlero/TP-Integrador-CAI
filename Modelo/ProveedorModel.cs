using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ProveedorModel
    {   
        private Guid _id;
        private string _nombre;
        private string _apellido;
        private string _estado;
        private List<int> _categoriasProductos;

        public Guid Id { get => _id; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public List<int> CategoriasProductos { get => _categoriasProductos; set => _categoriasProductos = value; }

        public ProveedorModel(Guid id, string nombre, string apellido, string estado, List<int> categoriasProductos) 
        { 
            // Las que tienen mayuscula son las que tienen setter
            _id = id;
            Nombre = nombre;
            Apellido = apellido;
            Estado = estado;
            CategoriasProductos = categoriasProductos;
        }

    }
}
