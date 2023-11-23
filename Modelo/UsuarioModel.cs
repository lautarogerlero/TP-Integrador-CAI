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
        private DateTime _fechaNacimiento;
        private string _usuario;
        private int _host; // perfil
        private int _dni;
        private string _contrasenia;

        // Propiedades
        // Las que tienen set es porque se pueden cambiar, las que no tienen set se crean con el constructor y no cambian más
        public string IdUsuario { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime FechaNacimiento { get => _fechaNacimiento; }
        public string NombreUsuario { get => _usuario; set => _usuario = value; }
        public int Host { get => _host; }
        public int Dni { get => _dni; }
        public string Contraseña { get => _contrasenia; set => _contrasenia = value; }

        // Constructor
        public UsuarioModel(string id, string nombre, string apellido, string direccion, string telefono, string email, DateTime fechaNacimiento, string usuario, int host, int dni)
        {
            // Las que tienen mayuscula son las que tienen setter
            IdUsuario = id;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            _fechaNacimiento = fechaNacimiento;
            NombreUsuario = usuario;
            _host = host;
            _dni = dni;
            Contraseña = "PrimerLoginG3";
        }

        public override string ToString()
        {
            return $"ID: {IdUsuario}, Nombre: {Nombre}, Apellido: {Apellido}, Direccion: {Direccion}, Telefono: {Telefono}, Email: {Email}," +
                $" Fecha Nacimiento: {FechaNacimiento}, Usuario: {NombreUsuario}, Host: {Host}, DNI: {Dni}, Contraseña: {Contraseña}";
        }
    }
}