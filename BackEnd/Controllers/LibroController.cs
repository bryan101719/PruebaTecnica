namespace BackEnd.Controllers
{
    using BackEnd.Repository.Clases;
    using BackEnd.Repository.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Model;
    using System;

    public class LibroController : Controller
    {
        private readonly IRepositorioLibro repositorioLibro;

        public LibroController()
        {
            repositorioLibro = new RepositorioLibro();
        }

        [HttpPost, Route("ConsultarLibros")]
        public ActionResult ConsultarLibros()
        {
            var resultado = repositorioLibro.ConsultarLibros();
            return Json(resultado);
        }

        [HttpPost, Route("AgregarLibro")]
        public ActionResult AgregarLibro(Libro libro)
        {
            var resultado = repositorioLibro.CrearLibro(libro);
            return Json(resultado);
        }

        [HttpPost, Route("ModificarLibro")]
        public ActionResult ModificarLibro(Libro libro)
        {
            var resultado = repositorioLibro.ModificarLibro(libro);
            return Json(resultado);
        }

        [HttpPost, Route("EliminarLibro")]
        public ActionResult EliminarLibro(Libro libro)
        {
            var resultado = repositorioLibro.EliminarLibro(libro);
            return Json(resultado);
        }
    }
}
