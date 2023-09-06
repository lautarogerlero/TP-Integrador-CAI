// Contiene las acciones de negocio. Las clases sin atributos, solo con acciones
// Acá va a estar la clase usuario con todas sus acciones
// Por ejemplo: la clase usuario con el metodo crearUsuario
// Realiza las validaciones de negocio (las validaciones especificas de cada clase)
// El método crearUsuario crea una instancia de la clase Usuario de la capa de Modelo
// Ve a las otras dos capas
using Modelo;
namespace Negocio
{
    public class Usuario
    {
        //Lautaro
        // debe tener un método CrearUsuario que recibe los parametros necesarios para la creación
        // CrearUsuario tiene que llamar a otro método ValidarUsuario que valide que el nombre de usuarios cumpla los requisitos
        // Llama al método ValidarUsuario para verificar si el nombre de usuario cumple con los requisitos

        public static UsuarioModel CrearUsuario(string nombre, string apellido, string direccion, string telefono, string email, DateTime fechaNacimiento, string usuario, int host, int dni)
        {
            bool usuarioValido = ValidarUsuario(usuario, nombre, apellido);
            while (!usuarioValido)
            {
                Console.WriteLine("El nombre de usuario no cumple con los requisitos.\nPor favor, ingrese uno válido.");
                usuario = Console.ReadLine(); // Pedir nuevamente el nombre de usuario
                usuarioValido = ValidarUsuario(usuario, nombre, apellido);
            }
            // Crea una instancia de UsuarioModel
            UsuarioModel nuevoUsuario = new UsuarioModel(nombre, apellido, direccion, telefono, email, fechaNacimiento, usuario, host, dni);

            // Retorna el usuario creado
            return nuevoUsuario;
        }

        private static bool ValidarUsuario(string usuario, string nombre, string apellido)l
        {
            // Normalizacion para que no haya problemas con las mayusculas/minusculas
            usuario = usuario.ToLower();
            nombre = nombre.ToLower();
            apellido = apellido.ToLower();

            // Validación del nombre de usuario. Verifica si tiene entre 8 y 15 caracteres y no contiene el nombre o apellido del usuario.
            bool cumpleRequisitos = usuario.Length >= 8 && usuario.Length <= 15 && !usuario.Contains(nombre) && !usuario.Contains(apellido);

            return cumpleRequisitos;
        }

        public static void SolicitarContrasenia(UsuarioModel usuario)
        {
            bool contraseniaValida = false;
            string newPassword;
            Console.Write("Ingrese la nueva contraseña: " +
                        "\nLa misma debe cumplir los siguientes requisitos: " +
                        "\n-Tener entre 8 y 15 caracteres entre letras y números " +
                        "\n-Contener como mínimo una letra mayúscula y un número " +
                        "\n-No puede ser igual a la anterior\n");
            do
            {
                newPassword = Console.ReadLine();
                contraseniaValida = ValidarContrasenia(newPassword);
                if (!contraseniaValida)
                {
                    Console.WriteLine("La contraseña no cumple alguno de los requisitos. Intente nuevamente");
                }
            } while (!contraseniaValida);
            usuario.Contrasenia = newPassword;

            //return newPassword;

        }

        static bool ValidarContrasenia(string password)
        {
            // Requisito 1: La contraseña debe tener entre 8 y 15 caracteres alfanuméricos.
            if (password.Length < 8 || password.Length > 15)
            {
                return false;
            }

            // Requisito 2: La contraseña debe contener al menos una letra mayúscula y un número.
            bool mayuscula = false, numero = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    mayuscula = true;
                }

                else if (char.IsDigit(c))
                {
                    numero = true;
                }
            }
            if (mayuscula && numero)
            {
                return true;
            }
            return false;
        }

    // Otro método login que permita iniciar sesión con el nombre de usuario y la contraseña. En este caso, si es el primer login
    // debe solicitar cambiar la contraseña y el estado del usuario (capa Modelo) pasará a ser ACTIVO
    public static bool LogIn(string usuario, string contrasenia)
        {
        // ES LA PRIMERA VEZ QUE INGRESA?
        if (PrimerLogin == true)
        {
            Console.WriteLine("Bienvenido, debe cambiar su contraseña");
            SolicitarContrasenia();
            UsuarioModel.PrimerLogin = false;
            UsuarioModel.Estado = "ACTIVO";
        }

        else
        {
            // 2- TENGO QUE CAMBIAR LA CONTRASEÑA? else
            // _diasContrasenia en realidad deberia ser una fecha, que se actualiza cada vez que se actualiza la pw.
            //  else if (HOY - user.last_update_pw > 30 dias)
            //  SolicitarContrasenia
            //  ultima fecha actualizacion pw = HOY() (_diasContrasenia -> deberia ser una fecha)
        }


        return true;
    }

    }
}

