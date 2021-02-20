using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoMapper;
using Moq;
using NUnit.Framework;
using RestApiModeloDDD.Application;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Domain.Core.Interfaces.Services;
using RestApiModeloDDD.Domain.Entitys;

namespace RestApiModeloDDD.Tests
{
    [TestFixture]
    public class ApplicationServiceClienteTests
    {

        private static Fixture _fixture;
        private Mock<IServiceCliente> _serviceClienteMock;
        private Mock<IMapper> _mapperMock;
        

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _serviceClienteMock = new Mock<IServiceCliente>();
            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public void ApplicationServiceCliente_GetAll_ShouldReturnFiveClients()
        {
            //Arrange
            var clientes = _fixture.Build<Cliente>().CreateMany(5);
            var clientesDto = _fixture.Build<ClienteDto>().CreateMany(5);

            _serviceClienteMock.Setup(x => x.GetAll()).Returns(clientes);
            _mapperMock.Setup(x => x.Map<IEnumerable<ClienteDto>>(clientes)).Returns(clientesDto);

            var applicationServiceCliente = new ApplicationServiceCliente(_serviceClienteMock.Object, _mapperMock.Object);
            
            //Act
            var result = applicationServiceCliente.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            _serviceClienteMock.VerifyAll();
            _mapperMock.VerifyAll();
        }
        
        [Test]
        public void ApplicationServiceCliente_GetById_ShouldReturnClient()
        {
            //Arrange
            const int id = 10;
     
            var cliente = _fixture.Build<Cliente>()
                .With(c => c.Id, id)
                .With(c => c.Email, "teste1@teste.com.br")
                .Create();
            
            var clienteDto = _fixture.Build<ClienteDto>()
                .With(c => c.Id, id)
                .With(c => c.Email, "teste1@teste.com.br")
                .Create();
            
            _serviceClienteMock.Setup(x => x.GetById(id)).Returns(cliente);
            _mapperMock.Setup(x => x.Map<ClienteDto>(cliente)).Returns(clienteDto);

            var applicationServiceCliente =
                new ApplicationServiceCliente(_serviceClienteMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceCliente.GetById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("teste1@teste.com.br", result.Email);
            Assert.AreEqual(10, result.Id);
            _serviceClienteMock.VerifyAll();
            _mapperMock.VerifyAll();
            
            
        }

    }
}