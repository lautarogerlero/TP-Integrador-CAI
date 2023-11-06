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
    }
}
