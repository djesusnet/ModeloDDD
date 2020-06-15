using AutoMapper;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Application.Interfaces;
using RestApiModeloDDD.Domain.Core.Interfaces.Services;
using RestApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;

namespace RestApiModeloDDD.Application
{
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente serviceCliente;
        private readonly IMapper mapper;
        public ApplicationServiceCliente(IServiceCliente serviceCliente
                                       , IMapper mapper)
        {
            this.serviceCliente = serviceCliente;
            this.mapper = mapper;
        }
        public void Add(ClienteDto clienteDto)
        {
            var cliente = mapper.Map<Cliente>(clienteDto);
            serviceCliente.Add(cliente);
        }

        public IEnumerable<ClienteDto> GetAll()
        {
            var clientes = serviceCliente.GetAll();
            var clientesDto = mapper.Map<IEnumerable<ClienteDto>>(clientes);

            return clientesDto;
        }

        public ClienteDto GetById(int id)
        {
            var cliente = serviceCliente.GetById(id);
            var clienteDto = mapper.Map<ClienteDto>(cliente);

            return clienteDto;
        }

        public void Remove(ClienteDto clienteDto)
        {
            var cliente = mapper.Map<Cliente>(clienteDto);
            serviceCliente.Remove(cliente);
        }

        public void Update(ClienteDto clienteDto)
        {
            var cliente = mapper.Map<Cliente>(clienteDto);
            serviceCliente.Update(cliente);
        }
    }
}
