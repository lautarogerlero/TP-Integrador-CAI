﻿// Contiene la lógica principal
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;

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
        static string menu_admin = "1) Agregar usuario \n2) Registrar proveedor \n3) Dar de baja proveedor \n4) Agregar producto \n5) Registrar cliente \n6) Modificar cliente \n7) Ver stock crítico \n8) Ventas por clientes \n9) Productos más vendidos por categoría \nX) Cerrar sesión";
        static string menu_supervisor = "1) Agregar producto \n2) Devolver venta \n3) Ver stock crítico \n4) Ventas por clientes \n5) Productos más vendidos por categoría \nX) Cerrar sesión";
        static string menu_vendedor = "1) Registrar venta \n2) Ventas por clientes \nX) Cerrar sesión";

        static int productosConStrockCritico = 0;
        static List<JToken> listaProductosConStrockCritico = new List<JToken>();

        static void Main(string[] args)
        {
            CargaInicialDatos();

            MenuPrincipal();
        }

        private static void CargaInicialDatos()
        {
            // Crear los 3 usuarios que deben estar cargados cuando se inicia el programa
            UsuarioModel administrador1 = new UsuarioModel("D347CE99-DB8D-4542-AA97-FC9F3CCE6969", "Administrador", "Administrador", "Economicas 123", "44444444", "administrador@economicas.com", new DateTime(2000, 01, 01), "AdminiG3", 1, 11111111);
            administrador1.Contraseña = "CAI20232";
            //administrador1.PrimerLogin = false;
            //administrador1.Estado = "ACTIVO";

            Usuarios.Add(administrador1);

            UsuarioModel supervisor1 = new UsuarioModel("D347CE99-DB8D-4542-AA97-FC9F3CCE6969", "Supervisor", "Supervisor", "Economicas 456", "55555555", "supervisor@economicas.com", new DateTime(2000, 01, 01), "SupervG3", 2, 22222222);
            supervisor1.Contraseña = "CAI20232";
            Usuarios.Add(supervisor1);

            UsuarioModel vendedor1 = new UsuarioModel("D347CE99-DB8D-4542-AA97-FC9F3CCE6969", "Vendedor", "Vendedor", "Economicas 789", "66666666", "vendedor@economicas.com", new DateTime(2000, 01, 01), "VendedG3", 3, 33333333);
            vendedor1.Contraseña = "CAI20232";
            Usuarios.Add(vendedor1);

            //foreach (var usuario in Usuarios)
            //{
            //    var jsonRequest = JsonConvert.SerializeObject(usuario);
            //    Console.WriteLine(jsonRequest.ToString());
            //    HttpResponseMessage response = WebHelper.Post("Usuario/AgregarUsuario", jsonRequest);


            //    if (!response.IsSuccessStatusCode)
            //    {
            //        throw new Exception(response.StatusCode.ToString());
            //    }
            //    else
            //    {
            //        Console.WriteLine("Usuario creado con exito!");
            //    }
            //}
        }

        private static void MenuPrincipal()
        {
            do
            // Mientras continuar = true
            {
                DibujarTitulo("EletroHogar SA");
                Console.WriteLine(menu_inicial);

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
                            string idUsuario = IniciarSesion();
                            //UsuarioModel usuarioLogueado = null;
                            bool cerrarMenu = false; // para controlar el flujo del segundo menú
                            string nuevaOpcion;

                            if (idUsuario == "")
                            {
                                Console.WriteLine("Ingrese una tecla para continuar.");

                                Console.ReadKey();
                                cerrarMenu = true;
                            }

                            while (!cerrarMenu) // mientras cerrarMenu = false;
                            {
                                JToken usuario = Usuario.ObtenerUsuarioPorId(idUsuario);
                                string nombreUsuario = usuario["nombreUsuario"].ToString();
                                int host = int.Parse(usuario["host"].ToString());
                                DibujarTitulo($"{nombreUsuario}");
                                // Si el host == 1, muestra el menú de Admin con la opción de agregar usuario
                                if (host == 1)
                                {
                                    // Muestra el MenuAdmin y devuelve un booleano para ver si sigue en el menú o cierra sesión
                                    cerrarMenu = MenuAdmin(cerrarMenu);
                                }
                                // Si el host es 2, muestra el menú supervisor
                                else if (host == 2)
                                {
                                    // Muestra el MenuVendedor y devuelve un booleano para ver si sigue en el menú o cierra sesión
                                    cerrarMenu = MenuSupervisor(cerrarMenu, idUsuario);
                                }
                                // Si el host es 3, muestra el menú vendedor
                                else if (host == 3)
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
                    Console.WriteLine("Ingrese una tecla para continuar.");

                    Console.ReadKey();
                }

            }
            while (continuarPrograma);
            Console.WriteLine("Gracias por usar la app.");
        }

        private static bool MenuAdmin(bool cerrarMenu)
        {
            if(productosConStrockCritico > 0)
            {
                Console.WriteLine($"Hay {productosConStrockCritico} producto/s con stock crítico!");
            }
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
            else if (nuevaOpcion == "2")
            {
                RegistrarProveedor();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "3")
            {
                DarDeBajaProveedor();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "4")
            {
                AgregarProducto();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "5")
            {
                AgregarCliente();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "6")
            {
                ModificarCliente();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "7")
            {
                MostrarStockCritico();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "8")
            {
                MostrarVentasPorClientes();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "9")
            {
                ProductosMasVendidos();
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

        private static bool MenuSupervisor(bool cerrarMenu, string idUsuario)
        {
            if (productosConStrockCritico > 0)
            {
                Console.WriteLine($"Hay {productosConStrockCritico} producto/s con stock crítico!!\n");
            }
            Console.WriteLine(menu_supervisor);
            string nuevaOpcion = Console.ReadLine();
            // Si elige X cierra sesión, sino pide de vuelta la opción
            if (nuevaOpcion == "1")
            {
                AgregarProducto();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "2")
            {
                DevolverVenta(idUsuario);
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "3")
            {
                MostrarStockCritico();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "4")
            {
                MostrarVentasPorClientes();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "5")
            {
                ProductosMasVendidos();
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
            Console.WriteLine(menu_vendedor);
            string nuevaOpcion = Console.ReadLine();
            // Si elige X cierra sesión, sino pide de vuelta la opción
            if (nuevaOpcion == "1")
            {
                RegistrarVenta();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "2")
            {
                MostrarVentasPorClientes();
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

        private static void AgregarUsuario()
        {
            // Pedir los atributos que necesita el usuario para ser creado
            string id = "D347CE99-DB8D-4542-AA97-FC9F3CCE6969";
            string nombre = ConsolaUtils.ValidarNombre("Ingrese el nombre");
            string apellido = ConsolaUtils.ValidarNombre("Ingrese el apellido");
            string direccion = ConsolaUtils.PedirString("Ingrese la dirección");
            string telefono = ConsolaUtils.ValidarTelefono("Ingrese el número de teléfono");
            string email = ConsolaUtils.ValidarEmail("Ingrese el email");
            DateTime fechaNacimiento = ConsolaUtils.ValidarFechaNacimiento("Ingrese la fecha de nacimiento");
            int host = ConsolaUtils.PedirIntRango("Ingrese el número de host (Supervisor = 2, Vendedor = 3)", 2, 3);
            int dni = ConsolaUtils.ValidarDni("Ingrese el DNI");
            string usuario = ConsolaUtils.PedirString("Ingrese el nombre de usuario. \nEntre 8 y 15 caracteres y no puede contener ni nombre ni apellido");
            // una vez solicitados los atributos, llamar al metodo CrearUsuario de la capa de negocio
            Usuario.CrearUsuario(id, nombre, apellido, direccion, telefono, email, fechaNacimiento, usuario, host, dni);
            // Agrega el usuario creado a la lista de Usuarios
            //Usuarios.Add(nuevoUsuario);
        }

        private static void RegistrarProveedor()
        {
            string nombre = ConsolaUtils.ValidarNombre("Ingrese el nombre");
            string apellido = ConsolaUtils.ValidarNombre("Ingrese el apellido");
            string email = ConsolaUtils.ValidarEmail("Ingrese el email");
            string cuit = ConsolaUtils.PedirString("Ingrese el CUIT"); ;
            Proveedor.RegistrarProveedor(nombre, apellido, email, cuit);
        }

        private static void DarDeBajaProveedor()
        {
            string nombre = ConsolaUtils.ValidarNombre("Ingrese el nombre");
            string apellido = ConsolaUtils.ValidarNombre("Ingrese el apellido");
            Proveedor.DarDeBajaProveedor(nombre, apellido);
        }

        private static string IniciarSesion()
        {
            Login login = new Login();
            Dictionary<string, int> intentosPorUsuario = new Dictionary<string, int>();
            bool usuarioEncontrado;
            string idUsuario = "";
            string nombreUsuario;
            do
            {
                nombreUsuario = ConsolaUtils.PedirString("Ingrese su nombre de usuario");
                string contraseña = ConsolaUtils.PedirString("Ingrese su contraseña. \nSi es la primera vez que inicia sesión, ingrese la contraseña 'PrimerLoginG3' y cambie la contraseña para poder continuar");
                login.NombreUsuario = nombreUsuario;
                login.Contraseña = contraseña;

                try
                {
                    idUsuario = Usuario.LogIn(login, nombreUsuario, contraseña);
                    Console.WriteLine("Login exitoso");
                    usuarioEncontrado = true;
                    // Si el inicio de sesión es exitoso, restablece el contador de intentos fallidos.
                    intentosPorUsuario.Remove(login.NombreUsuario);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Usuario o contraseña incorrectos");
                    Console.WriteLine(ex.Message);
                    usuarioEncontrado = false;
                    // Incrementa el contador de intentos fallidos para este NombreUsuario.
                    if (intentosPorUsuario.ContainsKey(login.NombreUsuario))
                    {
                        intentosPorUsuario[login.NombreUsuario]++;
                    }
                    else
                    {
                        intentosPorUsuario[login.NombreUsuario] = 1;
                    }
                    Console.WriteLine($"Le queda/n {3 - intentosPorUsuario[login.NombreUsuario]} intento/s");
                    // Verifica si el usuario ha superado el número máximo de intentos permitidos. Si lo superó, borra al usuario
                    if (intentosPorUsuario[login.NombreUsuario] >= 3)
                    {
                        Console.WriteLine("Alcanzó el límite de intentos. Su usuario ha sido bloqueado");
                        string idABorrar = ObtenerIdUsuario(login.NombreUsuario);
                        BorrarUsuario(idABorrar);
                        nombreUsuario = "";
                        break;
                    }
                }
            } while (!usuarioEncontrado);

            return idUsuario;
        }

        private static void BorrarUsuario(string idUsuario)
        {
            try
            {
                Usuario.BorrarUsuario(idUsuario);
                Console.WriteLine("Usuario borrado exitosamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static string ObtenerIdUsuario(string nombreUsuario)
        {
            string idUsuario = "";
            JToken usuario = Usuario.ObtenerUsuarioPorNombre(nombreUsuario);
            if (usuario != null)
            {
                idUsuario = usuario["id"].ToString();
            }
            return idUsuario;
        }

        private static void AgregarProducto()
        {
            int categoria = ConsolaUtils.PedirIntRango("Ingrese la categoría de producto (1-5)", 1, 5);
            string nombreProducto = ConsolaUtils.PedirString("Ingrese el nombre del producto");
            int precio = ConsolaUtils.PedirIntRango("Ingrese el precio del producto", 1, 100000000);
            int stock = ConsolaUtils.PedirIntRango("Ingrese el stock del producto", 1, 1000000);
            string nombre = ConsolaUtils.ValidarNombre("Ingrese el nombre del proveedor");
            string apellido = ConsolaUtils.ValidarNombre("Ingrese el apellido del proveedor");
            JToken proveedor = Proveedor.ObtenerProveedorPorNombre(nombre, apellido);
            if (proveedor == null)
            {
                Console.WriteLine("El proveedor ingresado no fue encontrado en la base de datos");
            }
            else
            {
                string idProveedor = proveedor["id"].ToString();
                Producto.RegistrarProducto(categoria, idProveedor, nombreProducto, precio, stock);
            }
        }

        private static void AgregarCliente()
        {
            // Pedir los atributos que necesita el usuario para ser creado
            string id = "D347CE99-DB8D-4542-AA97-FC9F3CCE6969";
            string nombre = ConsolaUtils.ValidarNombre("Ingrese el nombre");
            string apellido = ConsolaUtils.ValidarNombre("Ingrese el apellido");
            string direccion = ConsolaUtils.PedirString("Ingrese la dirección");
            string telefono = ConsolaUtils.ValidarTelefono("Ingrese el número de teléfono");
            string email = ConsolaUtils.ValidarEmail("Ingrese el email");
            DateTime fechaNacimiento = ConsolaUtils.ValidarFechaNacimiento("Ingrese la fecha de nacimiento");
            string host = ConsolaUtils.PedirString("Ingrese el host");
            int dni = ConsolaUtils.ValidarDni("Ingrese el DNI");
            Cliente.CrearCliente(id, nombre, apellido, direccion, telefono, email, fechaNacimiento, host, dni);
        }

        private static void ModificarCliente()
        {
            string nombre = ConsolaUtils.ValidarNombre("Ingrese el nombre del cliente");
            string apellido = ConsolaUtils.ValidarNombre("Ingrese el apellido del cliente");
            Cliente.ModificarCliente(nombre, apellido);
        }

        private static void RegistrarVenta()
        {
            bool valoresCorrectos = false;
            do
            {
                string nombreCliente = ConsolaUtils.ValidarNombre("Ingrese el nombre del cliente");
                string apellidoCliente = ConsolaUtils.ValidarNombre("Ingrese el apellido del cliente");
                string nombreUsuario = ConsolaUtils.PedirString("Ingrese el nombre de usuario");
                string nombreProducto = ConsolaUtils.PedirString("Ingrese el nombre del producto");

                JToken cliente = Cliente.ObtenerClientePorNombre(nombreCliente, apellidoCliente);
                JToken usuario = Usuario.ObtenerUsuarioPorNombre(nombreUsuario);
                JToken producto = Producto.ObtenerProductoPorNombre(nombreProducto);

                if (cliente != null && usuario != null && producto != null)
                {
                    valoresCorrectos = true;
                    string idCliente = cliente["id"].Value<string>();
                    string idUsuario = usuario["id"].Value<string>();
                    string idProducto = producto["id"].Value<string>();

                    int stock = Producto.ObtenerStock(nombreProducto);
                    int cantidad = ConsolaUtils.PedirIntRango($"Ingrese la cantidad. El stock disponible es {stock}", 1, stock);
                    Venta.RegistrarVenta(idCliente, idUsuario, idProducto, cantidad);
                    Venta.MostrarResumenVenta(cliente, producto, cantidad);

                    if (stock - cantidad < cantidad * 0.25)
                    {
                        productosConStrockCritico += 1;
                        listaProductosConStrockCritico.Add(producto);
                    }
                }
                else
                {
                    Console.WriteLine("Alguno de los datos ingresados no existe en la base de datos");
                }
            } while(!valoresCorrectos);
        }

        public static void DevolverVenta(string idUsuario)
        {
            bool valoresCorrectos = false;
            do
            {
                string nombreCliente = ConsolaUtils.ValidarNombre("Ingrese el nombre del cliente");
                string apellidoCliente = ConsolaUtils.ValidarNombre("Ingrese el apellido del cliente");

                JToken cliente = Cliente.ObtenerClientePorNombre(nombreCliente, apellidoCliente);

                if (cliente != null)
                {
                    string idCliente = cliente["id"].Value<string>();

                    int cantidad = ConsolaUtils.PedirIntRango($"Ingrese la cantidad vendida", 1, 10000000);

                    valoresCorrectos = Venta.DevolverVenta(cantidad, idCliente, idUsuario);
                }
                else
                {
                    Console.WriteLine("Alguno de los datos ingresados no existe en la base de datos");
                }
            } while (!valoresCorrectos);
        }

        public static void MostrarStockCritico()
        {
            Dictionary<int, List<(string Nombre, int Stock)>> productosAgrupados = new Dictionary<int, List<(string, int)>>();

            if(productosConStrockCritico > 0)
            {
                foreach (JToken producto in listaProductosConStrockCritico)
                {
                    string nombreProducto = producto["nombre"].Value<string>();
                    int idCategoria = producto["idCategoria"].Value<int>();
                    int stock = Producto.ObtenerStock(nombreProducto);

                    if (!productosAgrupados.ContainsKey(idCategoria))
                    {
                        productosAgrupados[idCategoria] = new List<(string, int)>();
                    }

                    productosAgrupados[idCategoria].Add((nombreProducto, stock));
                }

                foreach (var categoriaProductos in productosAgrupados)
                {
                    int idCategoria = categoriaProductos.Key;
                    Console.WriteLine($"Productos en stock crítico de categoría {idCategoria}:");

                    foreach (var producto in categoriaProductos.Value)
                    {
                        Console.WriteLine($"  Nombre: {producto.Nombre}, Stock: {producto.Stock}");
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No hay productos con stock crítico");
            }
        }

        public static void MostrarVentasPorClientes()
        {
            string clientes = Cliente.ObtenerListaClientes();
            JArray arrayClientes = JArray.Parse(clientes);

            string nombreClienteMasVentas = "";
            string apellidoClienteMasVentas = "";
            int maxVentas = 0;

            foreach (JObject clienteJson in arrayClientes)
            {
                string idCliente = clienteJson["id"].Value<string>();
                string nombre = clienteJson["nombre"].Value<string>();
                string apellido = clienteJson["apellido"].Value<string>();
                string ventasPorCliente = Venta.ObtenerVentasPorCliente(idCliente);
                JArray arrayVentas = JArray.Parse(ventasPorCliente);

                if(arrayVentas.Count > 0)
                {
                    Console.WriteLine($"Cliente {nombre} {apellido}");
                    Console.WriteLine("Ventas realizadas:");
                    foreach (JObject venta in arrayVentas)
                    {
                        string idVenta = venta["id"].Value<string>();
                        int cantidad = venta["cantidad"].Value<int>();
                        Console.WriteLine($"Id Venta: {idVenta} \nCantidad vendida: {cantidad}");
                    }
                    Console.WriteLine();
                    if(arrayVentas.Count > maxVentas)
                    {
                        maxVentas = arrayVentas.Count;
                        nombreClienteMasVentas = nombre;
                        apellidoClienteMasVentas = apellido;
                    }
                }        
            }
            Console.WriteLine($"El cliente con que más ventas realizó es {nombreClienteMasVentas} {apellidoClienteMasVentas} con {maxVentas} ventas");
        }

        public static void ProductosMasVendidos()
        {
            string clientes = Cliente.ObtenerListaClientes();
            JArray arrayClientes = JArray.Parse(clientes);

            foreach (JObject clienteJson in arrayClientes)
            {
                string idCliente = clienteJson["id"].Value<string>();
                string nombre = clienteJson["nombre"].Value<string>();
                string apellido = clienteJson["apellido"].Value<string>();
                string ventasPorCliente = Venta.ObtenerVentasPorCliente(idCliente);
                JArray arrayVentas = JArray.Parse(ventasPorCliente);

                if (arrayVentas.Count > 0)
                {
                    Console.WriteLine($"Cliente {nombre} {apellido}");
                    Console.WriteLine("Ventas realizadas:");
                    foreach (JObject venta in arrayVentas)
                    {
                        string idVenta = venta["id"].Value<string>();
                        int cantidad = venta["cantidad"].Value<int>();
                        Console.WriteLine($"Id Venta: {idVenta} \nCantidad vendida: {cantidad}");
                    }
                    Console.WriteLine();
                }
            }
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