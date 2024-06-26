﻿using FilmesApi.Data.Dtos;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto = _filmeService.AdicionaFilme(filmeDto);
            
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readDto = _filmeService.RecuperaFilmes(classificacaoEtaria);
            if (readDto != null)
            {
                return Ok(readDto);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            ReadFilmeDto readDto = _filmeService.RecuperaFilmesPorId(id);
            if (readDto != null)
            {
                return Ok(readDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result resultado = _filmeService.AtualizaFilme(id, filmeDto);

            if (resultado.IsSuccess)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result resultado = _filmeService.AtualizaFilme(id);

            if (resultado.IsSuccess)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}