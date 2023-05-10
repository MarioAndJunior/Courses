using FilmesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.Dtos.Sessao
{
    public class UpdateSessaoDto
    {
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
    }
}
