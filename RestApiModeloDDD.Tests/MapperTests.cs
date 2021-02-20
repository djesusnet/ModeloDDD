using AutoMapper;
using NUnit.Framework;
using RestApiModeloDDD.Application.Mappers;

namespace RestApiModeloDDD.Tests
{
    [TestFixture]
    public class MapperTests
    {
        [Test]
        public void AutoMapperDtoToModelCliente_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DtoToModelMappingCliente>());
            config.AssertConfigurationIsValid();
        }  
        
        [Test]
        public void AutoMapperModelToDtoCliente_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ModelToDtoMappingCliente>());
            config.AssertConfigurationIsValid();
        }
        
        [Test]
        public void AutoMapperDtoToModelProduto_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DtoToModelMappingProduto>());
            config.AssertConfigurationIsValid();
        }
        
        [Test]
        public void AutoMapperModelToDtoProduto_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ModelToDtoMappingProduto>());
            config.AssertConfigurationIsValid();
        }  

    }
}