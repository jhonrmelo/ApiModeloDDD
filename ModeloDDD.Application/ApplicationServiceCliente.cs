using ModeloDDD.Application.DTO;
using ModeloDDD.Application.Exceptions;
using ModeloDDD.Application.Interfaces;
using ModeloDDD.Application.Interfaces.Mappers;
using ModeloDDD.Domain.Core.Interfaces.Services;
using ModeloDDD.Domain.Entities;

using System.Collections.Generic;

namespace ModeloDDD.Application
{
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente _serviceCliente;
        private readonly IMapperCliente _mapperCliente;

        public ApplicationServiceCliente(IServiceCliente serviceCliente, IMapperCliente mapperCliente)
        {
            _serviceCliente = serviceCliente;
            _mapperCliente = mapperCliente;
        }

        public void Add(ClienteDTO clienteDTO)
        {
            Cliente cliente = _mapperCliente.MapperDtoToEntity(clienteDTO);
            _serviceCliente.Add(cliente);
        }

        public IEnumerable<ClienteDTO> GetAll()
        {
            var clientes = _serviceCliente.GetAll();
            return _mapperCliente.MapperListClientesToDto(clientes);
        }

        public ClienteDTO GetById(int id)
        {
            Cliente cliente = _serviceCliente.GetById(id);
            return _mapperCliente.MapperEntityToDto(cliente);
        }

        public void Remove(int id)
        {
            Cliente cliente = _serviceCliente.GetById(id);

            if (cliente is null)
                throw new NotFoundException("A informação passada para a deleção não existe no banco de dados.");

            _serviceCliente.Remove(cliente);
        }

        public void Update(ClienteDTO clienteDTO)
        {
            Cliente cliente = _mapperCliente.MapperDtoToEntity(clienteDTO);
            _serviceCliente.Update(cliente);
        }
    }
}