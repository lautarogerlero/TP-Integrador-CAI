// Contiene las clases con los atributos y los constructores
// Acá va a estar la clase Usuario con todos sus atributos
using System.Globalization;

namespace Modelo
{
    public class UsuarioModel
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
        private string _usuario;
        private int _host; // perfil
        private int _dni;
        private string _contrasenia;
        private string _estado;
        private bool _primerLogin;
        private DateTime? _fechaContrasenia; // fecha del último cambio de contraseña
        private int _intentos; // Se usa para llevar registro de cuantas veces puso mal la contraseña

        // Propiedades
        // Las que tienen set es porque se pueden cambiar, las que no tienen set se crean con el constructor y no cambian más
        public string Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime FechaAlta { get => _fechaAlta; }
        public DateTime FechaNacimiento { get => _fechaNacimiento; }
        public DateTime? FechaBaja { get => _fechaBaja; } // El signo de pregunta es para que deje ponerlo en null cuando se crea
        public string Usuario { get => _usuario; set => _usuario = value; }
        public int Host { get => _host; }
        public int Dni { get => _dni; }
        public string Contrasenia { get => _contrasenia; set => _contrasenia = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public bool PrimerLogin { get => _primerLogin; set => _primerLogin = value; }
        public DateTime? FechaContrasenia { get => _fechaContrasenia; set => _fechaContrasenia = value; }
        public int intentos { get => _intentos; set => _intentos = value; }


        // Constructor
        public UsuarioModel(string id, string nombre, string apellido, string direccion, string telefono, string email, DateTime fechaNacimiento, string usuario, int host, int dni)
        {
            // Las que tienen mayuscula son las que tienen setter
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            _fechaAlta = DateTime.Now;
            _fechaNacimiento = fechaNacimiento;
            _fechaBaja = null;
            Usuario = usuario;
            _host = host;
            _dni = dni;
            Contrasenia = "12345";
            Estado = "INACTIVO";
            PrimerLogin = true;
            FechaContrasenia = null;
            intentos = 3;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Apellido: {Apellido}, Direccion: {Direccion}, Telefono: {Telefono}, Email: {Email}, " +
                $"Fecha Alta: {FechaAlta}, Fecha Nacimiento: {FechaNacimiento}, Usuario: {Usuario}, Host: {Host}, DNI: {Dni}, Contraseña: {Contrasenia}, " +
                $"Estado: {Estado}, Primer Login: {PrimerLogin}, Fecha Contraseña: {FechaContrasenia}";
        }
    }
}