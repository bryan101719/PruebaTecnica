namespace BackEnd.Repository.Clases
{
    using BackEnd.Repository.Interfaces;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class RepositorioLibro : IRepositorioLibro
    {
        #region Constantes
        const string conectionString = "Server=(localdb)\\servidor;Database=Libreria;User Id=usuarioLibreria;Password=usuarioLibreria;";
        const string spListarLibros = "ConsultarLibros";
        const string spAgregarLibro = "AgregarLibro";
        const string spModificarLibro = "ModificarLibro";
        const string spEliminarLibro = "EliminarLibro";
        #endregion

        public Respuesta ConsultarLibros()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spListarLibros, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sql.Open();
                        var response = new List<Libro>();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                response.Add(
                                    new Libro
                                    {
                                        IdLibro = reader.GetInt32(reader.GetOrdinal("IdLibro")),
                                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                        Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                                        NombreAutor = reader.GetString(reader.GetOrdinal("NombreAutor")),
                                        IdAutor = reader.GetInt32(reader.GetOrdinal("IdAutor"))
                                    }
                                );
                            }
                        }

                        respuesta.NumeroError = default(int);
                        respuesta.Resultado = response;
                        return respuesta;
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.NumeroError = 1;
                return respuesta;
            }
        }

        public Respuesta CrearLibro(Libro libro)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spAgregarLibro, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreLibro", libro.Nombre);
                        cmd.Parameters.AddWithValue("@FechaLibro", libro.Fecha);
                        cmd.Parameters.AddWithValue("@Autor", libro.IdAutor);
                        cmd.Parameters.Add("@Error", SqlDbType.Int);
                        cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
                        sql.Open();
                        cmd.ExecuteNonQuery();
                        respuesta.NumeroError = Convert.ToInt32(cmd.Parameters["@Error"].Value);
                        return respuesta;
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.NumeroError = 1;
                return respuesta;
            }
        }

        public Respuesta ModificarLibro(Libro libro)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spModificarLibro, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdLibro", libro.IdLibro);
                        cmd.Parameters.AddWithValue("@NombreLibro", libro.Nombre);
                        cmd.Parameters.AddWithValue("@FechaLibro", libro.Fecha);
                        cmd.Parameters.AddWithValue("@Autor", libro.IdAutor);
                        cmd.Parameters.Add("@Error", SqlDbType.Int);
                        cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
                        sql.Open();
                        cmd.ExecuteNonQuery();
                        respuesta.NumeroError = Convert.ToInt32(cmd.Parameters["@Error"].Value);
                        return respuesta;
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.NumeroError = 1;
                return respuesta;
            }
        }

        public Respuesta EliminarLibro(Libro libro)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spEliminarLibro, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdLibro", libro.IdLibro);
                        cmd.Parameters.Add("@Error", SqlDbType.Int);
                        cmd.Parameters["@Error"].Direction = ParameterDirection.Output;
                        sql.Open();
                        cmd.ExecuteNonQuery();
                        respuesta.NumeroError = Convert.ToInt32(cmd.Parameters["@Error"].Value);
                        return respuesta;
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.NumeroError = 1;
                return respuesta;
            }
        }

    }
}
