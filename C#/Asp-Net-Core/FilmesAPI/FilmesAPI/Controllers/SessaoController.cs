using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly SessaoService _sessaoService;
        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionaSessao(sessaoDto);
            
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IEnumerable<Sessao> RecuperaSessoes([FromQuery] string nomeDoFilme)
        {
            return _sessaoService.RecuperaSessoes();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            ReadSessaoDto readDto = _sessaoService.RecuperaSessaoPorId(id);
            if (readDto != null)
            {
                return Ok(readDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Result resultado = _sessaoService.AtualizaSessao(id, sessaoDto);
            if (resultado.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaSessao(int id)
        {
            Result resultado = _sessaoService.DeletaSessao(id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
