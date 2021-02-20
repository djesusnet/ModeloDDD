using AutoFixture;
using AutoMapper;
using Moq;
using NUnit.Framework;
using RestApiModeloDDD.Application;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Domain.Core.Interfaces.Services;
using RestApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RestApiModeloDDD.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ApplicationServiceClienteTests
    {
        private static Fixture _fixture;
        private Mock<IServiceCliente> _mockServiceCliente;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockServiceCliente = new Mock<IServiceCliente>();
            _mockMapper = new Mock<IMapper>();
        }

        [Test]
        public void ApplicationServiceCliente_GetAll_ShouldReturnClients()
        {
            //Arrange
            var clientes = _fixture.Build<Cliente>()
                                   .CreateMany(5);
            var clientesDto = _fixture.Build<ClienteDto>()
                                  .CreateMany(5);

            _mockServiceCliente.Setup(x => x.GetAll()).Returns(clientes);

            _mockMapper.Setup(x => x.Map<IEnumerable<ClienteDto>>(clientes)).Returns(clientesDto);

            var applicationServiceCliente = new ApplicationServiceCliente(_mockServiceCliente.Object, _mockMapper.Object);

            //Act
            var result = applicationServiceCliente.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            _mockServiceCliente.VerifyAll();
            _mockMapper.VerifyAll();
        }
    }
}