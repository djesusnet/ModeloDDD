using AutoMapper;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Domain.Entitys;

namespace RestApiModeloDDD.Application.Mappers
{
    public class ModelToDtoMappingProduto : Profile
    {
        public ModelToDtoMappingProduto()
        {
            ProdutoDtoMap();
        }
        private void ProdutoDtoMap()
        {
            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(x => x.Valor));
        }
    }
}
