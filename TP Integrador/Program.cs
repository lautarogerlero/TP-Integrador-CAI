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
        // Lista donde se van a guardar los usuarios
        private static List<UsuarioModel> Usuarios = new List<UsuarioModel>();
        // Para controlar el flujo del menú de login
        static bool continuarPrograma = true;
        // Distintos menus para cada caso
        static string menu_inicial = "1) Iniciar Sesión \nX) Salir";
        static string menu_admin = "1) Agregar usuario \nX) Cerrar Sesión";
        static string menu_basico = "X) Cerrar Sesión";
        static void Main(string[] args)
        {
            CargaInicialDatos();
            
            MenuPrincipal();
        }

        private static void CargaInicialDatos()
        {
            // Crear los 3 usuarios que deben estar cargados cuando se inicia el programa
            UsuarioModel administrador1 = new UsuarioModel("D347CE99-DB8D-4542-AA97-FC9F3CCE6969", "Admin", "Admin", "Economicas 123", "44444444", "administrador@economicas.com", new DateTime(2000, 01, 01), "Administrador1", 1, 11111111);
            administrador1.Contrasenia = "CAI20232";
            administrador1.PrimerLogin = false;
            administrador1.Estado = "ACTIVO";
            
            Usuarios.Add(administrador1);

            UsuarioModel supervisor1 = new UsuarioModel(Guid.NewGuid().ToString(), "Supervisor", "Supervisor", "Economicas 456", "55555555", "supervisor@economicas.com", new DateTime(2000, 01, 01), "Supervisor1", 2, 22222222);
            supervisor1.Contrasenia = "CAI20232";
            Usuarios.Add(supervisor1);

            UsuarioModel vendedor1 = new UsuarioModel(Guid.NewGuid().ToString(), "Vendedor", "Vendedor", "Economicas 789", "66666666", "vendedor@economicas.com", new DateTime(2000, 01, 01), "Vendedor1", 3, 33333333);
            vendedor1.Contrasenia = "CAI20232";
            Usuarios.Add(vendedor1);
        }

        private static void MenuPrincipal()
        {
            do
            // Mientras continuar = true
            {
                DibujarTitulo("EletroHogar SA");
                Console.WriteLine(menu_inicial);

                foreach (var usuario in Usuarios)
                {
                    Console.WriteLine(usuario.ToString());
                }

                try
                {
                    string opcionElegida = Console.ReadLine();

                    if (opcionElegida.ToUpper() == "X")
                    {
                        // Si elige X, termina la ejecución
                        continuarPrograma = false;
                        continue;
                    }

                    switch (opcionElegida)
                    {
                        case "1":
                            // Si elige 1, llama al método LogIn
                            UsuarioModel usuarioLogueado = Usuario.LogIn(Usuarios);
                            bool cerrarMenu = false; // para controlar el flujo del segundo menú
                            string nuevaOpcion;

                            if (usuarioLogueado == null)
                            {
                                Console.WriteLine("Ingrese una tecla para continuar.");

                                Console.ReadKey();
                                cerrarMenu = true;
                            }

                            while (!cerrarMenu) // mientras cerrarMenu = false;
                            {
                                DibujarTitulo($"{usuarioLogueado.Nombre}");
                                // Si el host == 1, muestra el menú de Admin con la opción de agregar usuario
                                if (usuarioLogueado.Host == 1)
                                {
                                    // Muestra el MenuAdmin y devuelve un booleano para ver si sigue en el menú o cierra sesión
                                    cerrarMenu = MenuAdmin(cerrarMenu);
                                }
                                // Si el host es 1 o 2, muestra el menú básico por ahora solo con la opción de cerrar sesión
                                else if (usuarioLogueado.Host  == 2 || usuarioLogueado.Host == 3)
                                {
                                    // Muestra el MenuVendedor y devuelve un booleano para ver si sigue en el menú o cierra sesión
                                    cerrarMenu = MenuVendedor(cerrarMenu);
                                }
                            }

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

            }
            while (continuarPrograma);
            Console.WriteLine("Gracias por usar la app.");
        }

        private static bool MenuAdmin(bool cerrarMenu)
        {
            Console.WriteLine(menu_admin);
            string nuevaOpcion = Console.ReadLine();
            // Si elige 1, agrega un usuario, si elige X sale, si elige otra cosa le vuelve a pedir una opción
            if (nuevaOpcion == "1")
            {
                AgregarUsuario();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion.ToUpper() == "X")
            {
                cerrarMenu = true;
                return cerrarMenu;
            }
            else
            {
                Console.WriteLine("Opción inválida.");
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                Console.Clear();
                return cerrarMenu;
            }
        }

        private static bool MenuVendedor(bool cerrarMenu)
        {
            Console.WriteLine(menu_basico);
            string nuevaOpcion = Console.ReadLine();
            // Si elige X cierra sesión, sino pide de vuelta la opción
            if (nuevaOpcion.ToUpper() == "X")
            {
                cerrarMenu = true;
                return cerrarMenu;
            }
            else
            {
                Console.WriteLine("Opción inválida.");
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                Console.Clear();
                return cerrarMenu;
            }
        }

        private static void AgregarUsuario()
        {
            // Pedir los atributos que necesita el usuario para ser creado
            string id = Guid.NewGuid().ToString();
            string nombre = ConsolaUtils.ValidarNombre("Ingrese el nombre");
            string apellido = ConsolaUtils.ValidarNombre("Ingrese el apellido");
            string direccion = ConsolaUtils.PedirString("Ingrese la dirección");
            string telefono = ConsolaUtils.ValidarTelefono("Ingrese el número de teléfono");
            string email = ConsolaUtils.ValidarEmail("Ingrese el email");//en prueba
            DateTime fechaNacimiento = ConsolaUtils.ValidarFechaNacimiento("Ingrese la fecha de nacimiento");
            int host = ConsolaUtils.PedirHost("Ingrese el número de host (Supervisor = 2, Vendedor = 3)");
            int dni = ConsolaUtils.ValidarDni("Ingrese el DNI");
            string usuario = ConsolaUtils.PedirString("Ingrese el nombre de usuario. \nEntre 8 y 15 caracteres y no puede contener ni nombre ni apellido");
            // una vez solicitados los atributos, llamar al metodo CrearUsuario de la capa de negocio
            UsuarioModel nuevoUsuario = Usuario.CrearUsuario(id, nombre, apellido, direccion, telefono, email, fechaNacimiento, usuario, host, dni);
            // Agrega el usuario creado a la lista de Usuarios
            Usuarios.Add(nuevoUsuario);
        }

        private static void DibujarTitulo(String titulo)
        {
            Console.Clear();
            String separador = "";
            String separadorTitulo = "";
            int cantidadMaxima = 0;

            if (titulo.Length % 2 == 0)
            {
                cantidadMaxima = 64;
            }
            else
            {
                cantidadMaxima = 63;
            }

            for (int i = 0; i < cantidadMaxima + 2; i++)
            {
                separador = separador + "-";
            }

            for (int i = 0; i < ((cantidadMaxima - titulo.Length) / 2); i++)
            {
                separadorTitulo = separadorTitulo + "-";
            }


            Console.WriteLine(separador);
            Console.WriteLine(separadorTitulo + " " + titulo + " " + separadorTitulo);
            Console.WriteLine(separador);
        }
    }
}
