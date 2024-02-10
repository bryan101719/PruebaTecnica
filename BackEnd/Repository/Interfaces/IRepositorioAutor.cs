namespace BackEnd.Repository.Interfaces
{
    using Model;
    public interface IRepositorioAutor
    {
        Respuesta ConsultarAutores();
        Respuesta CrearAutor(Autor autor);
        Respuesta ModificarAutor(Autor autor);
        Respuesta EliminarAutor(Autor autor);

    }
}