namespace Negocio.Clases
{
    using Model;
    using Negocio.Interfaces;
    using RestSharp;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;

    public class LibroNegocio : ILibroNegocio
    {
        public IEnumerable<Libro> ConsultarLibros()
        {
            var client = new RestClient("https://localhost:44327/ConsultarLibros");
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);
            Respuesta respuesta = Newtonsoft.Json.JsonConvert.DeserializeObject<Respuesta>(response.Content);
            if (respuesta.NumeroError == default(int)) 
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Libro>>(respuesta.Resultado.ToString());
            }
            else
            {
                return null;
            }
        }

        public Respuesta AgregarLibro(Libro libro)
        {
            var client = new RestClient("https://localhost:44327/AgregarLibro");
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddObject(libro);
            IRestResponse response = client.Execute(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Respuesta>(response.Content);
        }

        public Respuesta ModificarLibro(Libro libro)
        {
            var client = new RestClient("https://localhost:44327/ModificarLibro");
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddObject(libro);
            IRestResponse response = client.Execute(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Respuesta>(response.Content);
        }

        public Respuesta EliminarLibro(Libro libro)
        {
            var client = new RestClient("https://localhost:44327/EliminarLibro");
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddObject(libro);
            IRestResponse response = client.Execute(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Respuesta>(response.Content);
        }
    }
}
