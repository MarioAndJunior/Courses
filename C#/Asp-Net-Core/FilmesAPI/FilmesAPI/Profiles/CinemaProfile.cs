using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>()
                .ForMember(cinema => cinema.Gerente, opts => opts
                .MapFrom(cinema => new { cinema.Gerente.Id, cinema.Gerente.Nome }));
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
