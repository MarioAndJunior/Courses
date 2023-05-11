using FilmesApi.Data.Dtos;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readCinemaDto =_cinemaService.AdicionaCinema(cinemaDto);
           
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = readCinemaDto.Id }, readCinemaDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> readDto = _cinemaService.RecuperaCinemas(nomeDoFilme);
            if (readDto == null)
            {
                return NotFound();
            }

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto readDto = _cinemaService.RecuperaCinemasPorId(id);
            if(readDto != null)
            {
                return Ok(readDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = _cinemaService.AtualizaCinema(id, cinemaDto);
            if (resultado.IsSuccess)
            {
                return NoContent();
            }

            return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result resultado = _cinemaService.AtualizaCinema(id);
            if (resultado.IsSuccess)
            {
                return NoContent();
            }

            return NotFound();
        }

    }
}
