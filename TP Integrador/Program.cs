// Contiene la lógica principal
// Por ejemplo: pedir el input del usuario
// Realiza las validaciones de integridad de datos (las validaciones generales)
// Estas validaciones pueden estar en una carpeta aparte como en el ejemplo de Agenda
// Llama al método crearUsuario de la clase Usuario de la capa de Negocio
// Solo ve la capa de Negocio, no la de Modelo
using System;
using System.ComponentModel;
using Negocio;
using Utils;
using Modelo;

namespace TPIntegrador
{
    internal class Program
    {
        static List<UsuarioModel> Usuarios = new List<UsuarioModel>();
        static void Main(string[] args)
        {
            UsuarioModel administrador1 = new UsuarioModel("Patricia", "Bertagnoli", "Economicas 123", "44444444", "facultad@economicas.com", new DateTime(2000,01,01), "Administrador1", 1, 11111111);
            administrador1.Contrasenia = "CAI20232";
            Usuarios.Add(administrador1);

            bool continuar = true;

            string menu = "1) Iniciar Sesión \n2) Registrar usuario \nX) Salir";

            Console.WriteLine("Bienvenido al menú. Por favor elija una opción.");

            do
            {
                Console.WriteLine(menu);

                try
                {
                    string opcionElegida = Console.ReadLine();

                    if (opcionElegida.ToUpper() == "X")
                    {
                        // Si elige X, termina la ejecución
                        continuar = false;
                        continue;
                    }

                    switch (opcionElegida)
                    {
                        case "1":
                            // Si elige 1, llama al método LogIn
                            LogIn();
                            break;
                        case "2":
                            // Si elige 2, llama al método RegistrarUsuario
                            RegistrarUsuario();
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error durante la ejecución del comando. Por favor intente nuevamente. Mensaje: " + ex.Message);
                }
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                Console.Clear();
            }
            while (continuar);
            Console.WriteLine("Gracias por usar la app.");
        }

        private static void RegistrarUsuario()
        {
            bool usuarioCreado = false;
            do
            {
                // Pedir los atributos que necesita el usuario para ser creado
                string nombre = ConsolaUtils.ValidarNombre("Ingrese el nombre");
                string apellido = ConsolaUtils.ValidarNombre("Ingrese el apellido");
                string direccion = ConsolaUtils.PedirString("Ingrese la dirección");
                string telefono = ConsolaUtils.PedirString("Ingrese el número de teléfono");
                string email = ConsolaUtils.validarEmail("Ingrese el email");//en prueba
                DateTime fechaNacimiento = ConsolaUtils.ValidarFechaNacimiento("Ingrese la fecha de nacimiento");
                string usuario = ConsolaUtils.PedirString("Ingrese el nombre de usuario");
                int host = ConsolaUtils.PedirInt("Ingrese el número de host");
                int dni = ConsolaUtils.ValidarDni("Ingrese el DNI");
                // una vez solicitados los atributos, llamar al metodo CrearUsuario de la capa de negocio
                UsuarioModel nuevoUsuario = Usuario.CrearUsuario(nombre, apellido, direccion, telefono, email, fechaNacimiento, usuario, host, dni);
                Usuarios.Add(nuevoUsuario);
                // Si el usuario se creo con exito, usuarioCreado = true
                usuarioCreado = true;
                Console.WriteLine("Su contraseña para el primer LogIn es 12345");
                // Mostrar lista de usuarios
                foreach (var u in Usuarios)
                {
                    Console.WriteLine(u.ToString());
                }
            } while (!usuarioCreado);

        }
        private static void LogIn()
        {
            bool usuarioLogueado = false;
            do
            {
                // Pedir los atributos que necesita el usuario para logear
                string usuario = ConsolaUtils.PedirString("Ingrese el nombre de usuario");
                string contrasenia = ConsolaUtils.PedirString("Ingrese la contraseña del usuario");

                usuarioLogueado = Usuarios.Find(u => u.Usuario == usuario && u.Contrasenia == contrasenia);

                if (usuarioLogueado == false)
                {
                    Console.WriteLine("El usuario o la contraseña no existen");
                }
                else
                {
                    // llamar al metodo LogIn de la capa de negocio
                    usuarioLogueado = Usuario.LogIn(usuario, contrasenia);
                }

                // Si el usuario se logeo con exito, usuarioLogeado = true
                usuarioLogueado = true;

            } while (!usuarioLogueado);
        }
}
