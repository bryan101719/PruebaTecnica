namespace Model
{
    using System;

    public class Libro
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreAutor { get; set; }
        public int IdAutor { get; set; }
    }
}
