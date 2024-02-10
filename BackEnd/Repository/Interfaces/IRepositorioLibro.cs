namespace BackEnd.Repository.Interfaces
{
    using Model;
    public interface IRepositorioLibro
    {
        public Respuesta ConsultarLibros();
        public Respuesta CrearLibro(Libro libro);
        public Respuesta ModificarLibro(Libro libro);
        public Respuesta EliminarLibro(Libro libro);
    }
}