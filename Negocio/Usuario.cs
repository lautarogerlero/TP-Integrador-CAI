// Contiene las acciones de negocio. Las clases sin atributos, solo con acciones
// Acá va a estar la clase usuario con todas sus acciones
// Por ejemplo: la clase usuario con el metodo crearUsuario
// Realiza las validaciones de negocio (las validaciones especificas de cada clase)
// El método crearUsuario crea una instancia de la clase Usuario de la capa de Modelo
// Ve a las otras dos capas
using Modelo;
using Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Http;

namespace Negocio
{
    public class Usuario
    {
        public static UsuarioModel CrearUsuario(string id, string nombre, string apellido, string direccion, string telefono, string email, DateTime fechaNacimiento, string usuario, int host, int dni)
        {
            // Método para crear un usuario
            // Primero llama a ValidarUsuario para verificar que el nombre de usuario sea válido
            bool usuarioValido = ValidarUsuario(usuario, nombre, apellido);
            while (!usuarioValido)
            {
                Console.WriteLine("El nombre de usuario no cumple con los requisitos.\nPor favor, ingrese uno válido.");
                usuario = Console.ReadLine(); // Pedir nuevamente el nombre de usuario
                usuarioValido = ValidarUsuario(usuario, nombre, apellido);
            }
            // Una vez que se obtiene un nombre de usuario válido, crea una instancia de UsuarioModel
            UsuarioModel nuevoUsuario = new UsuarioModel(id, nombre, apellido, direccion, telefono, email, fechaNacimiento, usuario, host, dni);
            SolicitarContrasenia(nuevoUsuario);
            // Agrega al usuario a la base de datos
            var jsonRequest = JsonConvert.SerializeObject(nuevoUsuario);
            HttpResponseMessage response = WebHelper.Post("Usuario/AgregarUsuario", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
            else
            {
                Console.WriteLine("Usuario creado con exito!");
            }
            // Retorna el usuario creado
            return nuevoUsuario;
        }

        private static bool ValidarUsuario(string usuario, string nombre, string apellido)
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
            // Método que solicita una contraseña y verifica que sea válida
            bool contraseniaValida;
            string newPassword;
            Console.Write("Ingrese la nueva contraseña: " +
                        "\nLa misma debe cumplir los siguientes requisitos: " +
                        "\n-Tener entre 8 y 15 caracteres entre letras y números " +
                        "\n-Contener como mínimo una letra mayúscula y un número " +
                        "\n-No puede ser igual a la anterior\n");
            do
            {
                newPassword = Console.ReadLine();
                // Llama al método ValidarContrasenia para chequear que cumpla los requisitos
                contraseniaValida = ValidarContrasenia(newPassword, usuario);
                if (!contraseniaValida)
                {
                    Console.WriteLine("La contraseña no cumple alguno de los requisitos. Intente nuevamente");
                }
            } while (!contraseniaValida);
            //  Asigna la contraseña valida a usuario.Contrasenia
            usuario.Contrasenia = newPassword;
            // Cambia la fecha en la que se actualizó la contraseña
            usuario.FechaContrasenia = DateTime.Now;
        }

        static bool ValidarContrasenia(string password, UsuarioModel usuario)
        {
            // Requisito 1: La contraseña debe tener entre 8 y 15 caracteres alfanuméricos.
            if (password.Length < 8 || password.Length > 15)
            {
                return false;
            }

            // Requisito 2: La contraseña debe contener al menos una letra mayúscula y un número.
            bool mayuscula = false, numero = false, distintaAAnterior = false;

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
            // Requisito 3: La contraseña no debe ser igual a la anterior
            if (password.ToLower() != usuario.Contrasenia.ToLower())
            {
                distintaAAnterior = true;
            }
            if (mayuscula && numero && distintaAAnterior)
            {
                return true;
            }
            
            return false;
        }

        public static UsuarioModel LogIn(List<UsuarioModel> Usuarios)
        {
            // Método que pide usuario y contraseña y verifica que exista en la lista de usuarios
            UsuarioModel usuario;
            UsuarioModel usuarioCompleto = null;
            do
            {
                string nombreUsuario = ConsolaUtils.PedirString("Ingrese su nombre de usuario");
                string password = ConsolaUtils.PedirString("Ingrese su contraseña");
                // Primero busca que el nombre de usuario exista, para descontar intentos en caso de que ingrese mal la contraseña
                usuario = Usuarios.Find(u => u.Usuario == nombreUsuario);
                if (usuario != null)
                {
                    // Busca que en usuarios haya un usuario con ese nombre de usuario y esa contraseña
                    usuarioCompleto = Usuarios.Find(u => u.Usuario == nombreUsuario && u.Contrasenia == password);
                    if (usuarioCompleto == null)
                    {
                        // Si no encontro nada se resta 1 intento
                        usuario.intentos--;
                        if (usuario.intentos > 1)
                        {
                            Console.WriteLine($"Alguno de los datos solicitados no es correcto.\nLe quedan {usuario.intentos} intentos");
                        }
                        else if (usuario.intentos == 1)
                        {
                            Console.WriteLine($"Alguno de los datos solicitados no es correcto.\nLe queda {usuario.intentos} intento");
                        }
                        else
                        {
                            // Si se quedó sin intentos se inhabilita el usuario
                            Console.WriteLine($"Te has quedado sin intentos, el usuario {usuario.Usuario} queda INACTIVO");
                            usuario.Estado = "INACTIVO";
                            return null;
                        }
                    }
                    else
                    {
                        // Si es el primer login, pide una nueva contraseña, cambia PrimerLogin a false y estado a ACTIVO
                        if (usuario.PrimerLogin == true)
                        {
                            Console.WriteLine($"Bienvenida/o {usuario.Nombre}. Por ser la primera vez que inicia sesión debe establecer una nueva contraseña");
                            SolicitarContrasenia(usuario);
                            usuario.PrimerLogin = false;
                            usuario.Estado = "ACTIVO";
                        }
                        usuario.intentos = 3; // Vuelve el contador de intentos a 3
                        // chequear hace cuanto se cambio la contraseña
                        UltimoCambioContrasenia(usuario);
                    }
                }
                else
                {
                    Console.WriteLine("Alguno de los datos solicitados no es correcto.");
                }
                
            } while (usuario == null || (usuario.intentos > 0 && usuarioCompleto == null)); // Mientras le queden intentos y no haya encontrado un usuario

            return usuario;
        }

        private static void UltimoCambioContrasenia(UsuarioModel usuario)
        {

            //fecha actual
            DateTime fechaActual = DateTime.Now;
            // ultima fecha de cambio de contraseña de ese usuario 
            DateTime? fechaCambioContrasenia = usuario.FechaContrasenia;
            int diferenciaDias;
            // primero chequea si fechaCambioContrasenia tiene valor
            if(fechaCambioContrasenia.HasValue)
            {
                //Restamos fecha actual y la fecha de cambio de contraseña y verificamos si pasaron mas de 30 dias
                TimeSpan diferencia = fechaActual.Subtract(fechaCambioContrasenia.Value);
                diferenciaDias = diferencia.Days;
            }
            else
            {
                diferenciaDias = 0;
            }
            if (diferenciaDias >= 30)
            {
                Console.WriteLine("Pasaron más de 30 días desde que actualizó su contraseña, por lo que deberá cambiarla");
                SolicitarContrasenia(usuario);
            }

        }

        private static void DarDeBaja(UsuarioModel usuario)
        {
            usuario.Estado = "INACTIVO";
        }

    }
}
