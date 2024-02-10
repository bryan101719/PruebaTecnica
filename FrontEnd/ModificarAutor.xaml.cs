namespace FrontEnd
{
    using FrontEnd.Labels;
    using Model;
    using Negocio.Clases;
    using Negocio.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
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
    /// Lógica de interacción para ModificarAutor.xaml
    /// </summary>
    public partial class ModificarAutor : Window
    {
        #region Constantes
        const string Nombre = "Nombre";
        const string IdPais = "IdPais";
        const string IdCiudad = "IdCiudad";
        const string IdSexo = "IdSexo";
        #endregion

        #region Variables
        private IAutorNegocio autorNegocio;
        private Autor autor;
        #endregion

        #region Constructor
        public ModificarAutor(Autor autor)
        {
            InitializeComponent();
            this.EnlazarEventos();
            this.EstablecerDependencias();
            this.MapearAutor(autor);
            this.autor = autor;
        }

        #endregion

        #region Métodos privados
        private void EnlazarEventos()
        {
            this.BtnModificarAutor.Click += BtnModificarLibroClick;
        }


        private void BtnModificarLibroClick(object sender, RoutedEventArgs e)
        {
            Autor autor = new Autor();
            autor.IdAutor = this.autor.IdAutor;
            autor.Nombre = this.txtNombre.Text;
            var respuesta = this.autorNegocio.ModificarAutor(autor);
            MessageBox.Show(Application.Current.MainWindow, respuesta.NumeroError == default(int) ? LibrosEtiquetas.GuardadoCorrecto: LibrosEtiquetas.Error);
            this.Close();
        }

        private void EstablecerDependencias()
        {
            this.autorNegocio = new AutorNegocio();
        }
        private void MapearAutor(Autor autor)
        {
            this.txtNombre.Text = autor.Nombre;
        }
        #endregion
    }
}
