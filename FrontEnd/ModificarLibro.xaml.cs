namespace FrontEnd
{
    using FrontEnd.Labels;
    using Model;
    using Negocio.Clases;
    using Negocio.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// Lógica de interacción para CrearLibro.xaml
    /// </summary>
    public partial class ModificarLibro : Window
    {
        #region Constantes
        const string Nombre = "Nombre";
        const string IdAutor = "IdAutor";
        #endregion

        #region Variables
        private ILibroNegocio libroNegocio;
        private IAutorNegocio autorNegocio;
        private IEnumerable<Autor> listaAutores;
        private Libro libro;
        #endregion

        #region Constructor
        public ModificarLibro(Libro libro)
        {
            InitializeComponent();
            this.EnlazarEventos();
            this.EstablecerDependencias();
            this.CargarAutores();
            this.MapearLibro(libro);
            this.libro = libro;
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Enlaza eventos de cada control con los métodos.
        /// </summary>
        private void EnlazarEventos()
        {
            this.BtnModificarLibro.Click += BtnModificarLibroClick;
        }

        /// <summary>
        /// Evento click modificar libro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificarLibroClick(object sender, RoutedEventArgs e)
        {
            Libro libro = new Libro();
            libro.IdLibro = this.libro.IdLibro;
            libro.Nombre = this.txtNombre.Text;
            libro.Fecha = Convert.ToDateTime(this.txtFecha.Text, CultureInfo.CurrentCulture);
            libro.IdAutor = Convert.ToInt32(this.txtAutor.SelectedValue.ToString());
            var respuesta = this.libroNegocio.ModificarLibro(libro);
            MessageBox.Show(Application.Current.MainWindow, respuesta.NumeroError == default(int) ? LibrosEtiquetas.GuardadoCorrecto: LibrosEtiquetas.Error);
            this.Close();
        }

        /// <summary>
        /// Establece instancias de la clase.
        /// </summary>
        private void EstablecerDependencias()
        {
            this.libroNegocio = new LibroNegocio();
            this.autorNegocio = new AutorNegocio();
            this.listaAutores = new List<Autor>();
        }

        /// <summary>
        /// Carga los autores en el combo de autores.
        /// </summary>
        private void CargarAutores()
        {
            this.listaAutores = this.autorNegocio.ConsultarAutores();
            this.txtAutor.ItemsSource = this.listaAutores;
            this.txtAutor.DisplayMemberPath = Nombre;
            this.txtAutor.SelectedValuePath = IdAutor;
        }

        /// <summary>
        /// Mapea valores en formulario para su edición.
        /// </summary>
        /// <param name="libro"></param>
        private void MapearLibro(Libro libro)
        {
            this.txtNombre.Text = libro.Nombre;
            this.txtFecha.SelectedDate = libro.Fecha;
            this.txtAutor.SelectedValue = libro.IdAutor;
        }
        #endregion
    }
}
