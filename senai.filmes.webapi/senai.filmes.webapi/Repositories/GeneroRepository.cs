using Microsoft.AspNetCore.Mvc;
using senai.filmes.webapi.Domains;
using senai.filmes.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source=DEV101\\SQLEXPRESS; initial catalog=Filmes_Tarde; user Id=sa; pwd=sa@132;";

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdGenero, Nome FROM Genero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString()
                        };

                        generos.Add(genero);
                    }
                }
            }

            return generos;
        }


        public List<GeneroDomain> ListarUnico(int IdUnico)
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", IdUnico);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString()
                        };

                        generos.Add(genero);
                    return generos;
                    }
                return null;
                }
            }

        }
        public void Adicionar(GeneroDomain generoRecebido)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"INSERT INTO Genero (Nome) VALUES (@Nome)";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", generoRecebido.Nome);
                    rdr = cmd.ExecuteReader();
                }
            }
        }

        public void Atualizar(int IdAtualizar, GeneroDomain generoAtualizar)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = $"UPDATE Genero SET Nome ='@Nome' WHERE IdGenero = @ID";
                con.Open();
                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();
                    cmd.Parameters.AddWithValue("@ID", IdAtualizar);
                    if (rdr.Read())
                    {
                        cmd.Parameters.AddWithValue("@Nome", generoAtualizar.Nome);
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
                    cmd.Parameters.AddWithValue("@ID", IdDelete);
                    rdr = cmd.ExecuteReader();
                }
            }
        }
    }
}
