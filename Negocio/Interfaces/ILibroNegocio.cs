namespace Negocio.Interfaces
{
    using Model;
    using System.Collections.Generic;
    public interface ILibroNegocio
    {
        IEnumerable<Libro> ConsultarLibros();
        Respuesta AgregarLibro(Libro libro);
        Respuesta ModificarLibro(Libro libro);
        Respuesta EliminarLibro(Libro libro);
    }
}