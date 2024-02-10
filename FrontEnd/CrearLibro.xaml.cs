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
    public partial class CrearLibro : Window
    {
        #region Constantes
        const string Nombre = "Nombre";
        const string IdAutor = "IdAutor";
        #endregion

        #region Variables
        private ILibroNegocio libroNegocio;
        private IAutorNegocio autorNegocio;
        private IEnumerable<Autor> listaAutores;
        #endregion

        #region Constructor
        public CrearLibro()
        {
            InitializeComponent();
            this.EnlazarEventos();
            this.EstablecerDependencias();
            this.CargarAutores();
        }

        #endregion

        #region Métodos privados
        private void EnlazarEventos()
        {
            this.BtnCrearLibro.Click += BtnCrearLibroClick;
        }

        /// <summary>
        /// Evento click en crear libro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCrearLibroClick(object sender, RoutedEventArgs e)
        {
            Libro libro = new Libro();
            libro.Nombre = this.txtNombre.Text;
            libro.Fecha = Convert.ToDateTime(this.txtFecha.Text, CultureInfo.CurrentCulture);
            libro.IdAutor = Convert.ToInt32(this.txtAutor.SelectedValue.ToString());
            var respuesta = this.libroNegocio.AgregarLibro(libro);
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
        /// Método que carga autores en combo autores.
        /// </summary>
        private void CargarAutores()
        {
            this.listaAutores = this.autorNegocio.ConsultarAutores();
            this.txtAutor.ItemsSource = this.listaAutores;
            this.txtAutor.DisplayMemberPath = Nombre;
            this.txtAutor.SelectedValuePath = IdAutor;
        }
        #endregion
    }
}
