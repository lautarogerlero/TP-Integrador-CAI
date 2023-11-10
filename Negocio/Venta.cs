using Modelo;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Negocio
{
    public class Venta
    {
        public static void RegistrarVenta(string cliente, string usuario, string producto, int cantidad)
        {
            VentaModel nuevaVenta = new VentaModel(cliente, usuario, producto, cantidad);

            // Agregar el nuevo proveedor
            var jsonRequest = JsonConvert.SerializeObject(nuevaVenta);
            HttpResponseMessage response = WebHelper.Post("Venta/AgregarVenta", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
            else
            {
                Console.WriteLine($"La venta fue registrada con éxito");
            }
        }

        public static string ObtenerVentasPorCliente(string idCliente)
        {
            // Trae todos los proveedores activos
            string content = "";
            HttpResponseMessage response = WebHelper.Get($"Venta/GetVentaByCliente?id={idCliente}");
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

        public static bool DevolverVenta(int cantidad, string idCliente)
        {
            string ventas = ObtenerVentasPorCliente(idCliente);
            JArray jsonArray = JArray.Parse(ventas);
            JToken venta = jsonArray.FirstOrDefault(item => (int)item["cantidad"] == cantidad);

            string idVenta = venta["id"].Value<string>();

            if( idVenta != null )
            {
                Dictionary<String, String> map = new Dictionary<String, String>();

                map.Add("id", idVenta);
                map.Add("idUsuario", idCliente);

                var jsonRequest = JsonConvert.SerializeObject(map);

                HttpResponseMessage response = WebHelper.Patch("Venta/DevolverVenta", jsonRequest);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Verifique los datos ingresados");
                }
                else
                {
                    Console.WriteLine("La devolución fue realizada con éxito");
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Alguno de los datos ingresados no existe en la base de datos");
                return false;
            }


        }
    }
}
