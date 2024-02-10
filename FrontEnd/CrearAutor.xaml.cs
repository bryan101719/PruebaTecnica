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
    using System.Windows;

    /// <summary>
    /// Lógica de interacción para ModificarAutor.xaml
    /// </summary>
    public partial class CrearAutor : Window
    {
        #region Constantes
        const string Nombre = "Nombre";
        const string IdPais = "IdPais";
        const string IdCiudad = "IdCiudad";
        const string IdSexo = "IdSexo";
        #endregion

        #region Variables
        private IAutorNegocio autorNegocio;
        #endregion

        #region Constructor
        public CrearAutor()
        {
            InitializeComponent();
            this.EnlazarEventos();
            this.EstablecerDependencias();
        }

        #endregion

        #region Métodos privados
        private void EnlazarEventos()
        {
            this.BtnCrearAutor.Click += BtnCrearLibroClick;
        }

        private void BtnCrearLibroClick(object sender, RoutedEventArgs e)
        {
            Autor autor = new Autor();
            autor.Nombre = this.txtNombre.Text;
            var respuesta = this.autorNegocio.AgregarAutor(autor);
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
