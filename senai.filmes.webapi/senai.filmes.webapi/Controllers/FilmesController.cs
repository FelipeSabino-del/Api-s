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
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            return _filmeRepository.Listar();
        }

        [HttpGet("{IdUnico}")]
        public IEnumerable<FilmeDomain> GetUnico(int IdUnico)
        {
            return _filmeRepository.ListarUnico(IdUnico);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain filmeRecebido)
        {
            _filmeRepository.Adicionar(filmeRecebido);
            return StatusCode(201);
        }

        [HttpPut("{IdAtualizar}")]
        public IActionResult Put(int IdAtualizar, FilmeDomain filmeAtualizar)
        {
            _filmeRepository.Atualizar(IdAtualizar, filmeAtualizar);
            return StatusCode(200);
        }

        [HttpDelete("{IdDelete}")]
        public IActionResult Delete(int IdDelete)
        {
            _filmeRepository.Deletar(IdDelete);
            return StatusCode(200);
        }
    }
}