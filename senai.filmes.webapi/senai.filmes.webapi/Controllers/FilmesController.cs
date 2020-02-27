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
        public IActionResult GetUnico(int IdUnico)
        {
            FilmeDomain filmeBuscado = _filmeRepository.ListarUnico(IdUnico);

            if (filmeBuscado != null)
            {
                return Ok(filmeBuscado);
            }

            return NotFound("Nenhum filme encontrado para o identificador informado");
        }

        [HttpGet("{Busca}")]
        public IEnumerable<FilmeDomain> GetPesquisa(string Busca)
        {
            return _filmeRepository.ListarPesquisa(Busca);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain filmeRecebido)
        {
            _filmeRepository.Adicionar(filmeRecebido);
            return Created("http://localhost:5000/api/Filmes", filmeRecebido);
        }

        [HttpPut("{IdAtualizar}")]
        public IActionResult Put(FilmeDomain filmeAtualizar, int IdAtualizar)
        {
            FilmeDomain filmeBuscado = _filmeRepository.ListarUnico(IdAtualizar);

            if (filmeBuscado != null)
            {
                try
                {
                    _filmeRepository.Atualizar(filmeAtualizar, IdAtualizar);
                    return NoContent();
                }
                catch (Exception erro)
                {

                    return BadRequest(erro);
                }
            }

            return NotFound
                (
                    new
                    {
                        mensagem = "Filme não encontrado",
                        erro = true
                    }
                );
        }

        [HttpDelete("{IdDelete}")]
        public IActionResult Delete(int IdDelete)
        {
            FilmeDomain filmeBuscado = _filmeRepository.ListarUnico(IdDelete);

            if (filmeBuscado != null)
            {
                _filmeRepository.Deletar(IdDelete);
                return Ok($"O filme {IdDelete} foi deletado com sucesso!");
            }
            return NotFound("Nenhum filme encontrado para o identificador informado");
        }
    }
}