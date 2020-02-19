using senai.filmes.webapi.Domains;
using senai.filmes.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source=DEV101\\SQLEXPRESS; initial catalog=Filmes_Tarde; user Id=sa; pwd=sa@132;";

        public void Adicionar(FilmeDomain filmeRecebido)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"INSERT INTO Genero (Titulo, IdGenero) VALUES ('@Nome', '@ID')";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", filmeRecebido.Titulo);
                    cmd.Parameters.AddWithValue("@ID", filmeRecebido.IdGenero);

                    if (filmeRecebido.IdGenero != filmeRecebido.Genero.IdGenero)
                    {
                    rdr = cmd.ExecuteReader();
                        
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }
        }

        public void Atualizar(int IdAtualizar, FilmeDomain filmeAtualizar)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"UPDATE Filmes SET Titulo ='@Titulo', IdGenero = '@IdGenero' WHERE IdGenero = @ID";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();
                    cmd.Parameters.AddWithValue("@ID", filmeAtualizar.IdGenero);

                    if (rdr.Read())
                    {
                        cmd.Parameters.AddWithValue("@Titulo", filmeAtualizar.Titulo);
                        cmd.Parameters.AddWithValue("@IdGenero", filmeAtualizar.IdGenero);
                    }
                    
                }
            }
        }

        public void Deletar(int IdDelete)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"DELETE FROM Genero WHERE IdGenero = @ID";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();
                    cmd.Parameters.AddWithValue("@ID", IdDelete);
                }
            }
        }

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFilme, Titulo, Genero.Nome FROM Filmes INNER JOIN Genero ON Genero.IdGenero = Filmes.IdGenero";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                        filme.IdGenero = filme.Genero.IdGenero = Convert.ToInt32(rdr[0]);
                        filme.Genero.Nome = rdr["Nome"].ToString();

                        filmes.Add(filme);
                    }

                    return filmes;
                }
            }

        }

        public List<FilmeDomain> ListarUnico(int IdUnico)
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFilme, Titulo, Genero.Nome FROM Filmes INNER JOIN Genero ON Genero.IdGenero = Filmes.IdGenero WHERE IdFilme = @ID";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", IdUnico);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                        filme.IdGenero = filme.Genero.IdGenero = Convert.ToInt32(rdr[0]);
                        filme.Genero.Nome = rdr["Nome"].ToString();

                        filmes.Add(filme);
                        return filmes;
                    }
                    return null;

                }
            }


        }
    }
}
