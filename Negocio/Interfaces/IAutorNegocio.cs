namespace Negocio.Interfaces
{
    using Model;
    using System.Collections.Generic;
    public interface IAutorNegocio
    {
        IEnumerable<Autor> ConsultarAutores();
        Respuesta AgregarAutor(Autor autor);
        Respuesta ModificarAutor(Autor autor);
        Respuesta EliminarAutor(Autor autor);
    }
}