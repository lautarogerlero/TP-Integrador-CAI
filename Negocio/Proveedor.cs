using Modelo;
using Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Negocio
{
    public class Proveedor
    {
        // Lista de proveedores registrados
        static List<ProveedorModel> proveedores = new List<ProveedorModel>();

        // Método para registrar un nuevo proveedor
        public static void RegistrarProveedor(string nombre, string apellido, string email, string cuit)
        {
            // Crear un nuevo proveedor con un ID único, el nombre, el apellido, el estado "Activo" y las categorías de productos
            ProveedorModel nuevoProveedor = new ProveedorModel(nombre, apellido, email, cuit);

            // Agregar el nuevo proveedor
            var jsonRequest = JsonConvert.SerializeObject(nuevoProveedor);
            HttpResponseMessage response = WebHelper.Post("Proveedor/AgregarProveedor", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
            else
            {
                Console.WriteLine($"El proveedor {nombre} {apellido} fue registrado con éxito");
            }
        }

        public static string ObtenerListaProveedores()
        {
            // Trae todos los proveedores activos
            string content = "";
            HttpResponseMessage response = WebHelper.Get($"Proveedor/TraerProveedores");
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

        public static JToken ObtenerProveedorPorNombre(string nombre, string apellido)
        {
            // Busca en los usuarios activos a un usuario por el nombre de usuario y devuelve su id
            string idProveedor = "";
            string content = ObtenerListaProveedores();
            // Analizar el contenido JSON
            JArray jsonArray = JArray.Parse(content);
            // Buscar el objeto con nombreUsuario igual a "master"
            JToken proveedor = jsonArray.FirstOrDefault(item => (string)item["nombre"] == nombre && (string)item["apellido"] == apellido);

            return proveedor;
        }

        // Método para dar de baja un proveedor existente
        public static void DarDeBajaProveedor(string nombre, string apellido)
        {
            String IdUsuarioMaster = "D347CE99-DB8D-4542-AA97-FC9F3CCE6969";

            Dictionary<String, String> map = new Dictionary<String, String>();
            JToken proveedor = ObtenerProveedorPorNombre(nombre, apellido);
            if (proveedor == null)
            {
                Console.WriteLine("El proveedor ingresado no fue encontrado en la base de datos");
            }
            else
            {
                string idProveedor = proveedor["id"].ToString();
                map.Add("id", idProveedor);
                map.Add("idUsuario", IdUsuarioMaster);

                var jsonRequest = JsonConvert.SerializeObject(map);

                HttpResponseMessage response = WebHelper.DeleteConBody("Proveedor/BajaProveedor", jsonRequest);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Verifique los datos ingresados");
                }
                else
                {
                    Console.WriteLine("Proveedor eliminado");
                }
            }
        }
    }
}
