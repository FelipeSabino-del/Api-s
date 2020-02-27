using senai.filmes.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Interfaces
{
    interface IFilmeRepository
    {
        List<FilmeDomain> Listar();

        FilmeDomain ListarUnico(int IdUnico);

        List<FilmeDomain> ListarPesquisa(string Busca);

        void Adicionar(FilmeDomain filmeRecebido);

        void Atualizar(FilmeDomain filmeAtualizar, int IdAtualizar);

        void Deletar(int IdDelete);
    }
}
