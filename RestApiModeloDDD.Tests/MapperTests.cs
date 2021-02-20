using AutoMapper;
using NUnit.Framework;
using RestApiModeloDDD.Application.Mappers;
using System.Diagnostics.CodeAnalysis;

namespace RestApiModeloDDD.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MapperTests
    {
        [Test]
        public void AutoMapperDtoToModel_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DtoToModelMappingCliente>());
            config.AssertConfigurationIsValid();
        }

        [Test]
        public void AutoMapperModelToDto_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<DtoToModelMappingCliente>());
            config.AssertConfigurationIsValid();
        }
    }
}
