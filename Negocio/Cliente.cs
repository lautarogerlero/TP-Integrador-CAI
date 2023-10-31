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
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace Negocio
{
    public class Cliente
    {
        // Lista de clientes registrados
        static List<ClienteModel> clientes = new List<ClienteModel>();

        public static void CrearCliente(string id, string nombre, string apellido, string direccion, string telefono, string email, DateTime fechaNacimiento, int dni)
        {
            // Método para crear un Cliente
            // Una vez que se obtiene un nombre de cliente válido, crea una instancia de ClienteModel

            ClienteModel nuevoCliente = new ClienteModel(id, nombre, apellido, direccion, telefono, email, fechaNacimiento, dni);

            // Agrega al cliente a la base de datos
            var jsonRequest = JsonConvert.SerializeObject(nuevoCliente);
            HttpResponseMessage response = WebHelper.Post("Usuario/AgregarCliente", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
            else
            {
                Console.WriteLine($"El cliente {nombre} {apellido} fue registrado con éxito");
            }
        }


        public static string ObtenerListaClientes()
        {
            // Trae todos los clientes activos
            String IdUsuarioMaster = "D347CE99-DB8D-4542-AA97-FC9F3CCE6969";
            string content = "";
            HttpResponseMessage response = WebHelper.Get($"Cliente/GetCliente?id={IdUsuarioMaster}");
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

        public static JToken ObtenerClientePorNombre(string nombre, string apellido)
        {
            // Busca en los usuarios activos a un usuario por el nombre de usuario y devuelve su id
            string idCliente = "";
            string content = ObtenerListaClientes();
            // Analizar el contenido JSON
            JArray jsonArray = JArray.Parse(content);
            // Buscar el objeto con nombreUsuario igual a "master"
            JToken cliente = jsonArray.FirstOrDefault(item => (string)item["nombre"] == nombre && (string)item["apellido"] == apellido);

            return cliente;
        }

        public static void ModificarCliente(string nombre, string apellido, string direccion,string telefono, string email)
        {
            String IdUsuarioMaster = "D347CE99-DB8D-4542-AA97-FC9F3CCE6969";

            Dictionary<String, String> map = new Dictionary<String, String>();
            JToken cliente = ObtenerClientePorNombre(nombre, apellido);
            if (cliente == null)
            {
                Console.WriteLine("El cliente ingresado no fue encontrado en la base de datos");
            }
            else
            {
                map.Add("idUsuario", IdUsuarioMaster);
                map.Add("dirección", direccion);
                map.Add("telefono", telefono);
                map.Add("email", email);

                var jsonRequest = JsonConvert.SerializeObject(map);

                HttpResponseMessage response = WebHelper.Patch("Cliente/PatchCliente", jsonRequest);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Verifique los datos ingresados");
                }
                else
                {
                    Console.WriteLine("Cliente modificado");
                }
            }
        }

    }
}

