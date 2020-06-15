using AutoMapper;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Domain.Entitys;

namespace RestApiModeloDDD.Application.Mappers
{
    public class DtoToModelMappingCliente : Profile
    {
        public DtoToModelMappingCliente()
        {
            ClienteMap();
        }

        private void ClienteMap()
        {
            CreateMap<ClienteDto, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(x => x.Sobrenome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.DataCadastro, opt => opt.Ignore())
                .ForMember(dest => dest.IsAtivo, opt => opt.Ignore());

        }
    }
}
