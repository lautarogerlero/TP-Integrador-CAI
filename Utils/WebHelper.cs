using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class WebHelper
        //Tiene los metodos de GET, POST, PUT, PATCH, DELETE que usamos en el Web Service. El GET tiene solo el URL. El DELETESinBody tiene el URL y el ID, porque se le pasa el ID a borrar dentro de la URL, no se pasa como contenido (BajaCliente). El DELETEConBody si tiene URL y JSON. El POST, el PUT, el PATCH tienen el URL y el JSON que se carga.
    {
        static HttpClient client = new HttpClient();
        static string rutaBase = "https://cai-tp.azurewebsites.net/api/";

        public static HttpResponseMessage Get(string url)
        {
            var uri = rutaBase + url;

            HttpResponseMessage response = client.GetAsync(uri).Result;  // Blocking call!

            return response;
        }

        public static HttpResponseMessage Post(string url, String jsonRequest)
        {
            var uri = rutaBase + url;

            var data = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(uri, data).Result;

            return response;

        }

        public static HttpResponseMessage Put(string url, String jsonRequest)
        {
            var uri = rutaBase + url;

            var data = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(uri, data).Result;

            return response;

        }

        public static HttpResponseMessage Patch(string url, String jsonRequest)
        {
            var uri = rutaBase + url;

            var data = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PatchAsync(uri, data).Result;

            return response;

        }

        public static HttpResponseMessage DeleteSinBody(string url, string id)
        {
            var uri = rutaBase + url + $"?id={id}";

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(uri)
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            return response;
        }


        public static HttpResponseMessage DeleteConBody(string url, String jsonRequest)
        {
            var uri = rutaBase + url;

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(uri),
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.SendAsync(request).Result;

            return response;
        }
    }
}
