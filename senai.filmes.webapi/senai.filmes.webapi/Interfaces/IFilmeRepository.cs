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

        List<FilmeDomain> ListarUnico(int IdUnico);

        void Adicionar(FilmeDomain filmeRecebido);

        void Atualizar(int IdAtualizar, FilmeDomain filmeAtualizar);

        void Deletar(int IdDelete);
    }
}
