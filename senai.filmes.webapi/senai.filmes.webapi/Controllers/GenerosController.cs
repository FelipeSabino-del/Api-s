using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.filmes.webapi.Domains;
using senai.filmes.webapi.Interfaces;
using senai.filmes.webapi.Repositories;

namespace senai.filmes.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private IGeneroRepository _generoRepository { get; set; }

        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        [HttpGet("{IdUnico}")]
        public IEnumerable<GeneroDomain> GetUnico(int IdUnico)
        {
            return _generoRepository.ListarUnico(IdUnico);
        }
        [HttpGet]
        public IEnumerable<GeneroDomain> Get()
        {
            return _generoRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(GeneroDomain generoRecebido)
        {
            _generoRepository.Adicionar(generoRecebido);
            return StatusCode(201);
        }

        [HttpPut("{IdAtualizar}")]
        public IActionResult Put(int IdAtualizar, GeneroDomain generoAtualizar)
        {
            _generoRepository.Atualizar(IdAtualizar, generoAtualizar);
            return StatusCode(200);
        }

        [HttpDelete("{IdDelete}")]
        public IActionResult Delete(int IdDelete)
        {
            _generoRepository.Deletar(IdDelete);
            return StatusCode(200);
        }
    }
}