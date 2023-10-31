using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

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
    }
}

