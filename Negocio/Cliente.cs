using Modelo;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Negocio
{
    public class Cliente
    {
        public static void CrearCliente(string id, string nombre, string apellido, string direccion, string telefono, string email, DateTime fechaNacimiento, string host, int dni)
        {
            // Método para crear un Cliente
            // Una vez que se obtiene un nombre de cliente válido, crea una instancia de ClienteModel

            ClienteModel nuevoCliente = new ClienteModel(id, nombre, apellido, dni, direccion, telefono, email, fechaNacimiento, host);

            // Agrega al cliente a la base de datos
            var jsonRequest = JsonConvert.SerializeObject(nuevoCliente);
            HttpResponseMessage response = WebHelper.Post("Cliente/AgregarCliente", jsonRequest);

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
            string content = "";
            HttpResponseMessage response = WebHelper.Get($"Cliente/GetClientes");
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
            JToken cliente = jsonArray.FirstOrDefault(item => (string)item["nombre"] == nombre && (string)item["apellido"] == apellido);

            return cliente;
        }

        public static void ModificarCliente(string nombre, string apellido)
        {
            Dictionary<String, String> map = new Dictionary<String, String>();
            JToken cliente = ObtenerClientePorNombre(nombre, apellido);
            if (cliente == null)
            {
                Console.WriteLine("El cliente ingresado no fue encontrado en la base de datos");
            }
            else
            {
                int opcion = ConsolaUtils.PedirIntRango("Ingrese 1 para modificar dirección, telefono e email, ingrese 2 para modificar estado", 1, 2);
                
                if (opcion == 1)
                {
                    string id = cliente["id"].ToString();
                    ModificarClienteAtributos(map, id);
                }
                else if (opcion == 2)
                {
                    string id = cliente["id"].ToString();
                    ModificarClienteEstado(map, id);
                } 
            }
        }

        private static void ModificarClienteAtributos(Dictionary<String, String> map, string id)
        {
            map.Add("id", id);
            string direccion = ConsolaUtils.PedirString("Ingrese la nueva dirección");
            string telefono = ConsolaUtils.ValidarTelefono("Ingrese el nuevo número de teléfono");
            string email = ConsolaUtils.ValidarEmail("Ingrese el nuevo email");
            map.Add("direccion", direccion);
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

        private static void ModificarClienteEstado(Dictionary<String, String> map, string id)
        {
            
            map.Add("id", id);

            var jsonRequest = JsonConvert.SerializeObject(map);

            HttpResponseMessage response = WebHelper.DeleteSinBody("Cliente/BajaCliente", id);

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
