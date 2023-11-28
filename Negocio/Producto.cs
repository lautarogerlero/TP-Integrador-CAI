using Modelo;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.WebService;

namespace Negocio
{
    public class Producto
    {
        public static void RegistrarProducto(int idCategoria, string idProveedor, string nombre, int precio, int stock)
        {
            string idMaster = "D347CE99-DB8D-4542-AA97-FC9F3CCE6969";
            ProductoModel nuevoProducto = new ProductoModel(idCategoria, idMaster, idProveedor, nombre, precio, stock);

            // Agregar el nuevo proveedor
            var jsonRequest = JsonConvert.SerializeObject(nuevoProducto);
            HttpResponseMessage response = WebHelper.Post("Producto/AgregarProducto", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
            else
            {
                Console.WriteLine($"El producto fue registrado con éxito");
            }
        }

        public static string ObtenerListaProductos()
        {
            // Trae todos los proveedores activos
            string content = "";
            HttpResponseMessage response = WebHelper.Get($"Producto/TraerProductos");
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

        public static JToken ObtenerProductoPorNombre(string nombre)
        {
            // Busca en los usuarios activos a un usuario por el nombre de usuario y devuelve su id
            string content = ObtenerListaProductos();
            // Analizar el contenido JSON
            JArray jsonArray = JArray.Parse(content);
            JToken producto = jsonArray.FirstOrDefault(item => (string)item["nombre"] == nombre);

            return producto;
        }

        public static int ObtenerStock(string nombre)
        {
            JToken producto = ObtenerProductoPorNombre(nombre);
            int stock = producto["stock"].Value<int>();

            return stock;
        }
    }
}
