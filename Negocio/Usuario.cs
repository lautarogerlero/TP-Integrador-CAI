using Modelo;
using Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace Negocio
{
    public class Usuario
    {
        public static void CrearUsuario(string id, string nombre, string apellido, string direccion, string telefono, string email, DateTime fechaNacimiento, string usuario, int host, int dni)
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

        public static void SolicitarContrasenia(string nombreUsuario, string passwordAnterior)
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
                contraseniaValida = ValidarContrasenia(newPassword, passwordAnterior);
                if (!contraseniaValida)
                {
                    Console.WriteLine("La contraseña no cumple alguno de los requisitos. Intente nuevamente");
                }
            } while (!contraseniaValida);
            //  Asigna la contraseña valida a usuario.Contrasenia
            ActualizarContrasenia(nombreUsuario, passwordAnterior, newPassword);
        }

        static bool ValidarContrasenia(string password, string anterior)
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
            if (password.ToLower() != anterior.ToLower())
            {
                distintaAAnterior = true;
            }
            if (mayuscula && numero && distintaAAnterior)
            {
                return true;
            }

            return false;
        }

        public static void ActualizarContrasenia(string nombreUsuario, string contraseñaAnterior, string contraseñaNueva)
        {
            Dictionary<String, String> map = new Dictionary<String, String>();

            map.Add("nombreUsuario", nombreUsuario);
            map.Add("contraseña", contraseñaAnterior);
            map.Add("contraseñaNueva", contraseñaNueva);

            var jsonRequest = JsonConvert.SerializeObject(map);

            HttpResponseMessage response = WebHelper.Patch("Usuario/CambiarContraseña", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
            else
            {
                Console.WriteLine("Contraseña actualizada!");
            }
        }
        public static string LogIn(Login login, string nombreUsuario, string password)
        {
            var jsonRequest = JsonConvert.SerializeObject(login);

            HttpResponseMessage response = WebHelper.Post("Usuario/Login", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }

            var reader = new StreamReader(response.Content.ReadAsStream());

            String respuesta = reader.ReadToEnd();

            if (password == "PrimerLoginG3")
            {
                SolicitarContrasenia(nombreUsuario, password);
            }

            return respuesta;
        }

        public static void BorrarUsuario(string idUsuario)
        {
            String IdUsuarioMaster = "D347CE99-DB8D-4542-AA97-FC9F3CCE6969";

            Dictionary<String, String> map = new Dictionary<String, String>();
            map.Add("id", idUsuario);
            map.Add("idUsuario", IdUsuarioMaster);

            var jsonRequest = JsonConvert.SerializeObject(map);

            HttpResponseMessage response = WebHelper.DeleteConBody("Usuario/BajaUsuario", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
        }

        public static string ObtenerListaUsuarios()
        {
            // Trae todos los usuarios activos
            String IdUsuarioMaster = "D347CE99-DB8D-4542-AA97-FC9F3CCE6969";
            string content = "";
            HttpResponseMessage response = WebHelper.Get($"Usuario/TraerUsuariosActivos?id={IdUsuarioMaster}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Verifique los datos ingresados");
            }
            else
            {
                content = response.Content.ReadAsStringAsync().Result;
            }
            return content;
        }

        public static JToken ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            // Busca en los usuarios activos a un usuario por el nombre de usuario y devuelve su id
            string idUsuario = "";
            string content = ObtenerListaUsuarios();
            // Analizar el contenido JSON
            JArray jsonArray = JArray.Parse(content);

            JToken usuario = jsonArray.FirstOrDefault(item => (string)item["nombreUsuario"] == nombreUsuario);

            return usuario;
        }

        public static JToken ObtenerUsuarioPorId(string id)
        {
            // Busca en los usuarios activos a un usuario por el id
            string content = ObtenerListaUsuarios();
            // Analizar el contenido JSON
            JArray jsonArray = JArray.Parse(content);
            string idFinal = id.Trim('"');

            JToken usuario = jsonArray.FirstOrDefault(item => (string)item["id"] == idFinal);

            return usuario;
        }

    }
}

