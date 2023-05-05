using AutoMapper;
using FilmesApi.Models;
using FilmesApi.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>()
                .ForMember(endereco => endereco.Cinema, opts => opts
                .MapFrom(endereco => new {endereco.Cinema.Id, endereco.Cinema.Nome }));
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}
