using AutoMapper;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Domain.Entitys;

namespace RestApiModeloDDD.Application.Mappers
{
    public class ModelToDtoMappingCliente : Profile
    {

        public ModelToDtoMappingCliente()
        {
            ClienteDtoMap();
        }

        private void ClienteDtoMap()
        {
            CreateMap<Cliente, ClienteDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(x => x.Sobrenome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email));
        }
    }
}
