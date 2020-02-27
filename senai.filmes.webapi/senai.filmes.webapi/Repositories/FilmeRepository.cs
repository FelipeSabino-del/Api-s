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
                string query = $"INSERT INTO Filmes (Titulo, IdGenero) VALUES (@Titulo, @ID)";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filmeRecebido.Titulo);
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

        public void Atualizar(FilmeDomain filmeAtualizar, int IdAtualizar)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"UPDATE Filmes SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @ID";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", IdAtualizar);
                    cmd.Parameters.AddWithValue("@Titulo", filmeAtualizar.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filmeAtualizar.IdGenero);
                    rdr = cmd.ExecuteReader();
                }
            }
        }

        public void Deletar(int IdDelete)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"DELETE FROM Filmes WHERE IdFilme = @ID";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", IdDelete);
                    rdr = cmd.ExecuteReader();
                }
            }
        }

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFilme, Titulo, Genero.IdGenero, Genero.Nome FROM Filmes INNER JOIN Genero ON Genero.IdGenero = Filmes.IdGenero";

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
                            Titulo = rdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(rdr[2])
                        };
                        filme.Genero.IdGenero = Convert.ToInt32(rdr[2]);
                        filme.Genero.Nome = rdr["Nome"].ToString();

                        filmes.Add(filme);
                    }

                    return filmes;
                }
            }

        }

        public List<FilmeDomain> ListarPesquisa(string Busca)
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFilme, Titulo, Genero.IdGenero, Genero.Nome FROM Filmes INNER JOIN Genero ON Genero.IdGenero = Filmes.IdGenero WHERE Titulo LIKE %@pesquisa% ORDER BY Titulo DESC";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@pesquisa", Busca);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(rdr[2])

                        };

                        filme.Genero.IdGenero = Convert.ToInt32(rdr[2]);
                        filme.Genero.Nome = rdr["Nome"].ToString();

                        filmes.Add(filme);
                    }
                    return filmes;
                }
            }
        }

        public FilmeDomain ListarUnico(int IdUnico)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFilme, Titulo, Genero.IdGenero, Genero.Nome FROM Filmes INNER JOIN Genero ON Genero.IdGenero = Filmes.IdGenero WHERE IdFilme = @ID";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", IdUnico);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        // Instancia um objeto filme 
                        FilmeDomain filme = new FilmeDomain
                        {
                            // Atribui à propriedade IdFilme o valor da coluna "IdFilme" da tabela do banco
                            IdFilme = Convert.ToInt32(rdr["IdFilme"])

                            // Atribui à propriedade Titulo o valor da coluna "Titulo" da tabela do banco
                            ,
                            Titulo = rdr["Titulo"].ToString()

                            // Atribui à propriedade IdGenero o valor da coluna "IdGenero" da tabela do banco
                            ,
                            IdGenero = Convert.ToInt32(rdr["IdGenero"])

                            ,
                            Genero = new GeneroDomain
                            {
                                // Atribui à propriedade IdGenero o valor da coluna IdGenero da tabela do banco de dados
                                IdGenero = Convert.ToInt32(rdr["IdGenero"])

                                // Atribui à propriedade Nome o valor da coluna Nome da tabela do banco de dados
                                ,
                                Nome = rdr["Nome"].ToString()
                            }
                        };
                        return filme;
                    }
                    return null;
                }


            }
        }
    }
}
