using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ClienteModel
    {
        // Atributos
        private string _id;
        private string _nombre;
        private string _apellido;
        private int _dni;
        private string _direccion;
        private string _telefono;
        private string _email;
        private DateTime _fechaNacimiento;
        private string _host; // perfil
        
        // Propiedades
        // Las que tienen set es porque se pueden cambiar, las que no tienen set se crean con el constructor y no cambian más
        public string IdUsuario { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public int Dni { get => _dni; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime FechaNacimiento { get => _fechaNacimiento; }
        public string Host { get => _host; }


        // Constructor
        public ClienteModel(string id, string nombre, string apellido, int dni, string direccion, string telefono, string email, DateTime fechaNacimiento, string host)
        {
            // Las que tienen mayuscula son las que tienen setter
            IdUsuario = id;
            Nombre = nombre;
            Apellido = apellido;
            _dni = dni;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            _fechaNacimiento = fechaNacimiento;
            _host = host;
        }
    }
}
