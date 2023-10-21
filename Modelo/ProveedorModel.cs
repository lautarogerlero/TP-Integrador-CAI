using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ProveedorModel
    {   
        private string _idUsuario;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _cuit;

        public string IdUsuario { get => _idUsuario; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Email { get => _email; set => _email = value; }
        public string Cuit { get => _cuit; set => _cuit = value; }

        public ProveedorModel(string nombre, string apellido, string email, string cuit) 
        { 
            // Las que tienen mayuscula son las que tienen setter
            _idUsuario = "D347CE99-DB8D-4542-AA97-FC9F3CCE6969";
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Cuit = cuit;
        }

    }
}
