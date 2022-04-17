using AutoMapper;
using Locadora.Data.Dtos.Locacao;
using Rental.Models;

namespace Locadora.Profiles
{
    public class LocadoraProfile : Profile
    {
        public LocadoraProfile()
        {
            CreateMap<CreateLocadoraDto, Locacao>();
            CreateMap<Locacao, ReadLocadoraDto>();
            CreateMap<UpdateLocadoraDto, Locacao>();
            //.ForMember(dto => dto.HorarioDeInicio, opts => opts
            //.MapFrom(dto =>
            //dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }

    }
}
