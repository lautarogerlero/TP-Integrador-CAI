// Contiene las clases con los atributos y los constructores
// Acá va a estar la clase Cliente con todos sus atributos
using System.Globalization;
using System.Text.RegularExpressions;

namespace Modelo
{
    public class ClienteModel
    {
        // Atributos
        private string _id;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private string _telefono;
        private string _email;
        private DateTime _fechaAlta;
        private DateTime _fechaNacimiento;
        private DateTime? _fechaBaja; // El signo de pregunta es para que deje ponerlo en null cuando se crea
        private string _idusuario;
        private string _host; // Ingresar “Grupo X” 
        private int _dni;

        // Propiedades
        // Las que tienen set es porque se pueden cambiar, las que no tienen set se crean con el constructor y no cambian más
        public string Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre;}
        public string Apellido { get => _apellido;}
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime FechaAlta { get => _fechaAlta; }
        public DateTime FechaNacimiento { get => _fechaNacimiento; }
        public DateTime? FechaBaja { get => _fechaBaja; } // El signo de pregunta es para que deje ponerlo en null cuando se crea
        public string IdUsuario { get => _idusuario; }
        public string Host { get => _host; }
        public int Dni { get => _dni; }


        // Constructor
        public ClienteModel(string id, string nombre, string apellido, string direccion, string telefono, string email, DateTime fechaNacimiento, string usuario, int host, int dni)
        {
            // Las que tienen mayuscula son las que tienen setter
            Id = id;
            _nombre = nombre;
            _apellido = apellido;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            _fechaAlta = DateTime.Now;
            _fechaNacimiento = fechaNacimiento;
            _fechaBaja = null;
            _idusuario = dni.ToString();
            _host = "Grupo X";
            _dni = dni;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Apellido: {Apellido}, Direccion: {Direccion}, Telefono: {Telefono}, Email: {Email}, " +
                $"Fecha Alta: {FechaAlta}, Fecha Nacimiento: {FechaNacimiento}, Usuario: {IdUsuario}, Host: {Host}, DNI: {Dni}";
        }
    }
}