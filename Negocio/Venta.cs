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

        public static void MostrarResumenVenta(JToken cliente, JToken producto, int cantidad)
        {
            string nombreCliente = cliente["nombre"].Value<string>();
            string apellidoCliente = cliente["apellido"].Value<string>();
            string datosCliente = nombreCliente + " " + apellidoCliente;
            string idProducto = producto["id"].Value<string>();
            string nombreProducto = producto["nombre"].Value<string>();
            int precio = producto["precio"].Value<int>();
            int montoTotal = cantidad * precio;
            string nombrePromocion;
            double descuento;
            int categoriaProducto = producto["idCategoria"].Value<int>();
            double montoFinal;

            if (categoriaProducto == 3 && montoTotal > 100000)
            {
                descuento = 0.05;
                nombrePromocion = "Promo Electro Hogar ";
            }
            else
            {
                descuento = 0;
                nombrePromocion = "";
            }

            string clienteAntiguo = ObtenerVentasPorCliente(cliente["id"].Value<string>());
            if(clienteAntiguo == "[]")
            {
                descuento += 0.05;
                nombrePromocion += "Promo Cliente Nuevo";
            }
            montoFinal = montoTotal * (1 - descuento);

            Console.Clear();
            Console.WriteLine("EletroHogar SA");
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
            Console.WriteLine(datosCliente);
            Console.WriteLine("");
            Console.WriteLine("Detalle:");
            Console.WriteLine("Id: " + idProducto + " | Nombre: " + nombreProducto + " | Cantidad: " + cantidad + " | Monto unitario: " + precio.ToString("C2") + " | Monto total: " + montoTotal.ToString("C2"));
            Console.WriteLine("");
            Console.WriteLine("Nombre promoción: " + nombrePromocion);
            Console.WriteLine("Descuento: " + descuento.ToString("C2"));
            Console.WriteLine("");
            Console.WriteLine("Total a pagar: " + montoFinal.ToString("C2"));

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

        public static bool DevolverVenta(int cantidad, string idCliente, string idUsuario)
        {
            string ventas = ObtenerVentasPorCliente(idCliente);
            JArray jsonArray = JArray.Parse(ventas);
            JToken venta = jsonArray.FirstOrDefault(item => (int)item["cantidad"] == cantidad);

            string idVenta = venta["id"].Value<string>();

            if( idVenta != null )
            {
                Dictionary<String, String> map = new Dictionary<String, String>();

                map.Add("id", idVenta);
                // string idFinal = id.Trim('"');
                map.Add("idUsuario", idUsuario.Trim('"'));

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
