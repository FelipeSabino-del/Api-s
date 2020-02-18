using senai.filmes.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Interfaces
{
    interface IGeneroRepository
    {
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns> Retorna uma lista de gêneros
        /// </returns>
        List<GeneroDomain> Listar();

        List<GeneroDomain> ListarUnico(int IdUnico);

        void Adicionar(GeneroDomain generoRecebido);

        void Atualizar(int IdAtualizar, GeneroDomain generoAtualizar);

        void Deletar(int IdDelete);
    }
}
