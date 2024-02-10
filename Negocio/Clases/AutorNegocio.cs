namespace Negocio.Clases
{
    using Model;
    using Negocio.Interfaces;
    using RestSharp;
    using System.Collections.Generic;
    public class AutorNegocio : IAutorNegocio
    {
        public IEnumerable<Autor> ConsultarAutores()
        {
            var client = new RestClient("https://localhost:44327/ConsultarAutores");
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);
            Respuesta respuesta = Newtonsoft.Json.JsonConvert.DeserializeObject<Respuesta>(response.Content);
            if (respuesta.NumeroError == default(int))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Autor>>(respuesta.Resultado.ToString());
            }
            else
            {
                return null;
            }
        }

        public Respuesta AgregarAutor(Autor autor)
        {
            var client = new RestClient("https://localhost:44327/AgregarAutor");
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddObject(autor);
            IRestResponse response = client.Execute(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Respuesta>(response.Content);
        }

        public Respuesta ModificarAutor(Autor autor)
        {
            var client = new RestClient("https://localhost:44327/ModificarAutor");
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddObject(autor);
            IRestResponse response = client.Execute(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Respuesta>(response.Content);
        }

        public Respuesta EliminarAutor(Autor autor)
        {
            var client = new RestClient("https://localhost:44327/EliminarAutor");
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddObject(autor);
            IRestResponse response = client.Execute(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Respuesta>(response.Content);
        }
    }
}
