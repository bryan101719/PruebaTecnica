namespace BackEnd.Repository.Clases
{
    using BackEnd.Repository.Interfaces;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class RepositorioAutor : IRepositorioAutor
    {
        #region Constantes
        const string conectionString = "Server=(localdb)\\servidor;Database=Libreria;User Id=usuarioLibreria;Password=usuarioLibreria;";
        const string spListarAutores = "ConsultarAutores";
        const string spAgregarAutor = "AgregarAutor";
        const string spModificarAutor = "ModificarAutor";
        const string spEliminarAutor = "EliminarAutor";
        #endregion

        public Respuesta ConsultarAutores()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spListarAutores, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sql.Open();
                        var response = new List<Autor>();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                response.Add(
                                    new Autor
                                    {
                                        IdAutor = reader.GetInt32(reader.GetOrdinal("IdAutor")),
                                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                        CantidadLibros = reader.GetInt32(reader.GetOrdinal("CantidadLibros"))
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

        public Respuesta CrearAutor(Autor autor)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spAgregarAutor, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", autor.Nombre);
                        cmd.Parameters.Add("@Error", SqlDbType.Int).Direction = ParameterDirection.Output;
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

        public Respuesta ModificarAutor(Autor autor)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spModificarAutor, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdAutor", autor.IdAutor);
                        cmd.Parameters.AddWithValue("@Nombre", autor.Nombre);
                        cmd.Parameters.Add("@Error", SqlDbType.Int).Direction = ParameterDirection.Output;
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

        public Respuesta EliminarAutor(Autor autor)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spEliminarAutor, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdAutor", autor.IdAutor);
                        cmd.Parameters.Add("@Error", SqlDbType.Int).Direction = ParameterDirection.Output;
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
