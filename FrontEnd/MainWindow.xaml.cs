namespace FrontEnd
{
    using FrontEnd.Labels;
    using Model;
    using Negocio.Clases;
    using Negocio.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        private ILibroNegocio libroNegocio;
        private IAutorNegocio autorNegocio;
        private IEnumerable<Libro> listaLibros;
        private IEnumerable<Autor> listaAutores;
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            this.EstablecerDependencias();
            this.CargarLibros();
            this.CargarAutores();
            this.EnlazarEventos();
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Establece las instancias iniciales de la clase.
        /// </summary>
        private void EstablecerDependencias()
        {
            this.libroNegocio = new LibroNegocio();
            this.autorNegocio = new AutorNegocio();
            this.listaLibros = new List<Libro>();
            this.listaAutores = new List<Autor>();
        }

        /// <summary>
        /// Carga los autores en el grid.
        /// </summary>
        private void CargarAutores()
        {
            this.listaAutores = this.autorNegocio.ConsultarAutores();
            this.GrdAutor.ItemsSource = this.listaAutores;
            this.GrdAutor.Items.Refresh();
        }

        /// <summary>
        /// Carga los libros en el grid.
        /// </summary>
        private void CargarLibros()
        {
            this.listaLibros = this.libroNegocio.ConsultarLibros();
            this.GrdLibro.ItemsSource = this.listaLibros;
            this.GrdLibro.Items.Refresh();
        }

        /// <summary>
        /// Método para añadir los eventos a cada control.
        /// </summary>
        public void EnlazarEventos()
        {
            this.BtnCrearLibro.Click += BtnCrearLibroClick;
            this.BtnModificarLibro.Click += BtnModificarLibroClick;
            this.BtnEliminarLibro.Click += BtnEliminarLibroClick;
            this.BtnCrearAutor.Click += BtnCrearAutorClick;
            this.BtnModificarAutor.Click += BtnModificarAutorClick;
            this.BtnEliminarAutor.Click += BtnEliminarAutorClick;
        }

        /// <summary>
        /// Evento click en eliminar autor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminarAutorClick(object sender, RoutedEventArgs e)
        {
            if (this.GrdAutor.SelectedItems.Count > default(int))
            {
                var autorSelecionado = this.GrdAutor.SelectedItems.Cast<Autor>();
                this.autorNegocio.EliminarAutor(autorSelecionado.FirstOrDefault());
                this.CargarAutores();
            }
            else
            {
                MessageBox.Show(PrincipalEtiquetas.Errorseleccion);
            }
        }

        /// <summary>
        /// Evento click en modificar autor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificarAutorClick(object sender, RoutedEventArgs e)
        {
            if (this.GrdAutor.SelectedItems.Count > default(int))
            {
                var autorSelecionado = this.GrdAutor.SelectedItems.Cast<Autor>();
                var modalModificarAutor = new ModificarAutor(autorSelecionado.FirstOrDefault());
                modalModificarAutor.Owner = this;
                modalModificarAutor.ShowDialog();
                this.CargarAutores();
            }
            else
            {
                MessageBox.Show(PrincipalEtiquetas.Errorseleccion);
            }
        }

        /// <summary>
        /// Evento click en crear autor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCrearAutorClick(object sender, RoutedEventArgs e)
        {
            var modalCrearAutor = new CrearAutor();
            modalCrearAutor.Owner = this;
            modalCrearAutor.ShowDialog();
            this.CargarAutores();
        }

        /// <summary>
        /// Evento para eliminar libro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminarLibroClick(object sender, RoutedEventArgs e)
        {
            if (this.GrdLibro.SelectedItems.Count > default(int))
            {
                var libroSelecionado = this.GrdLibro.SelectedItems.Cast<Libro>();
                this.libroNegocio.EliminarLibro(libroSelecionado.FirstOrDefault());
                this.CargarLibros();
            }
            else
            {
                MessageBox.Show(PrincipalEtiquetas.Errorseleccion);
            }
        }

        /// <summary>
        /// Evento para modificar libro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificarLibroClick(object sender, RoutedEventArgs e)
        {
            if (this.GrdLibro.SelectedItems.Count > default(int))
            {
                var libroSelecionado = this.GrdLibro.SelectedItems.Cast<Libro>();
                var modalModificarLibro = new ModificarLibro(libroSelecionado.FirstOrDefault());
                modalModificarLibro.Owner = this;
                modalModificarLibro.ShowDialog();
                this.CargarLibros();
            }
            else
            {
                MessageBox.Show(PrincipalEtiquetas.Errorseleccion);
            }
        }

        /// <summary>
        /// Evento click del boton para abrir modal crear libro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCrearLibroClick(object sender, RoutedEventArgs e)
        {
            var modalCrearLibro = new CrearLibro();
            modalCrearLibro.Owner = this;
            modalCrearLibro.ShowDialog();
            this.CargarLibros();
        }
        #endregion
    }
}
