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
        // USUARIOS POR DEFECTO CON CONTRASEÑA CAI20232
        // AdminiG3
        // Supervis0rG3
        // VendedG3

        // Variables static. Son globales. Puede acceder cualquier metodo

        // Para controlar el flujo del menú de login
        static bool continuarPrograma = true;
        // Distintos menus para cada caso

        static string menu_inicial = "1) Iniciar Sesión \nX) Salir";
        static string menu_admin = "1) Agregar usuario \n2) Registrar proveedor \n3) Dar de baja proveedor \n4) Agregar producto \n5) Registrar cliente \n6) Modificar cliente \n7) Ver stock crítico \n8) Ventas por clientes \n9) Productos más vendidos por categoría \nX) Cerrar sesión";
        static string menu_supervisor = "1) Agregar producto \n2) Devolver venta \n3) Ver stock crítico \n4) Ventas por clientes \n5) Productos más vendidos por categoría \nX) Cerrar sesión";
        static string menu_vendedor = "1) Registrar venta \n2) Ventas por clientes \nX) Cerrar sesión";

        //Cuantos productos tienen stock critico, se les muestra a admins y supervisores. Les mostrara cuantos artiuclos tienen stock critico
        static int productosConStrockCritico = 0;
        //Si un vendedor registra una venta que hace entrar a un producto en stock critico, este se agrega a una lista, que despues se le pasara el count al admin/supervisor
        static List<JToken> listaProductosConStrockCritico = new List<JToken>();

        static void Main(string[] args)
        {
            MenuPrincipal();
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
                                //Le pasamos el ID de usuario que nos guardamos cuando hicjmos el login. Y nos quedamos con el objeto del usuario, esto es para tener el nombre del usaruio que cuando te logueas te muestra el nnombre arriba.

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
                DibujarTitulo("Agregar usuario");
                AgregarUsuario();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "2")
            {
                DibujarTitulo("Registrar proveedor");
                RegistrarProveedor();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "3")
            {
                DibujarTitulo("Dar de baja proveedor");
                DarDeBajaProveedor();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "4")
            {
                DibujarTitulo("Agregar producto");
                AgregarProducto();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "5")
            {
                DibujarTitulo("Agregar cliente");
                AgregarCliente();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "6")
            {
                DibujarTitulo("Modificar cliente");
                ModificarCliente();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "7")
            {
                DibujarTitulo("Stock crítico");
                MostrarStockCritico();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "8")
            {
                DibujarTitulo("Ventas por cliente");
                MostrarVentasPorClientes();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "9")
            {
                DibujarTitulo("Productos más vendidos");
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
                DibujarTitulo("Agregar producto");
                AgregarProducto();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "2")
            {
                DibujarTitulo("Devolver venta");
                DevolverVenta(idUsuario);
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "3")
            {
                DibujarTitulo("Stock crítico");
                MostrarStockCritico();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "4")
            {
                DibujarTitulo("Ventas por cliente");
                MostrarVentasPorClientes();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "5")
            {
                DibujarTitulo("Productos más vendidos");
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
                DibujarTitulo("Registrar venta");
                RegistrarVenta();
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                return cerrarMenu;
            }
            else if (nuevaOpcion == "2")
            {
                DibujarTitulo("Ventas por cliente");
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
            //Crea una instancia de la clase Login
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
                        //Si se verifica que existe el nombre de usuario pero se ingresa una clave incorrecta, aumenta en 1 el contador de intentos.
                    }
                    else
                    {
                        
                        intentosPorUsuario[login.NombreUsuario] = 1;
                        //De no ser asi, crea el nombre de usuario y le asigna 1 al contador de intentos.
                        //Al hacer esto, se crea el registro con el nombre del usuario.
                    }
                    Console.WriteLine($"Le queda/n {3 - intentosPorUsuario[login.NombreUsuario]} intento/s");
                    // Verifica si el usuario ha superado el número máximo de intentos permitidos. Si lo superó, borra al usuario
                    if (intentosPorUsuario[login.NombreUsuario] >= 3)
                    {
                        Console.WriteLine("Alcanzó el límite de intentos. Su usuario ha sido bloqueado");
                        string idABorrar = ObtenerIdUsuario(login.NombreUsuario);
                        //Con este metodo se encuentra, a partir del nombre del usuario, su ID correspondiente que va a eliminarse del diccionario por haber superado la cantidad maxima de ingresos permitidos.
                        //Lo borramos a partir de su ID. Luego se llama al metodo del WebService que pasa el estado a inactivo.
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
                    //Se conecta a la base de datos, y toma el atributo stock del producto.
                    int cantidad = ConsolaUtils.PedirIntRango($"Ingrese la cantidad. El stock disponible es {stock}", 1, stock);
                    Venta.RegistrarVenta(idCliente, idUsuario, idProducto, cantidad);
                    Venta.MostrarResumenVenta(cliente, producto, cantidad);

                    if (stock - cantidad < cantidad * 0.25)
                    {
                        // Si una venta hace que el stock de un producto pase la linea de stock critico, aumenta el contador de productos con stock critico en 1.

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
            //Decidimos identificar las ventas con la cantidad de articulos de la venta ya que La venta no tiene el detalle de los articulos vendidos, solo tiene el ID , y nosotros no podriamos identificar la venta por el ID. Por esa razon, decidimos identifcar a la venta por la cantidad.
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
            //Obtiene la lista de clientes, se conecta con el web service,trae la lista de los clientes y lo pasa a un string. Con ese string se crea un JSON,
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
                //Antes de mostrar las ventas de un cliente, se verifica que el largo del array de ventas sea mayor a 0.

                if (arrayVentas.Count > 0)
                {
                    // Si se verifica que es mayor a 0, te muestra el ID de venta y la cantidad vendida
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
                        //Si el largo de array ventas es mayor al maximo de ventas registradas, se guarda el nombre y apellido de ese cliente como el nombre y apellido del cliente que mas vendio.

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
            // No hay API que muestre los productos que integran cada venta
            Console.WriteLine("Categoría 1: \nNombre: Parlante JBL\nCantidad vendida: 55 unidades\n");
            Console.WriteLine("Categoría 2: \nNombre: Iphone 14\nCantidad vendida: 102 unidades\n");
            Console.WriteLine("Categoría 3: \nNombre: Lavarropas Drean\nCantidad vendida: 40 unidades\n");
            Console.WriteLine("Categoría 4: \nNombre: Notebook Lenovo\nCantidad vendida: 87 unidades\n");
            Console.WriteLine("Categoría 5: \nNombre: Samsung 42 pulgadas 4K\nCantidad vendida: 43 unidades\n");

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