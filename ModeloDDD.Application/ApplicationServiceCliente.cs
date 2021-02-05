using ModeloDDD.Application.DTO;
using ModeloDDD.Application.Exceptions;
using ModeloDDD.Application.Interfaces;

using ModeloDDD.Domain.Core.Interfaces.Services;
using ModeloDDD.Domain.Entities;
using System.Collections.Generic;
using AutoMapper;

namespace ModeloDDD.Application
{
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente _serviceCliente;
        private readonly IMapper _mapper;


        public ApplicationServiceCliente(IServiceCliente serviceCliente, IMapper mapper)
        {
            _serviceCliente = serviceCliente;
            _mapper = mapper;
        }

        public void Add(ClienteDTO clienteDTO)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            _serviceCliente.Add(cliente);
        }

        public IEnumerable<ClienteDTO> GetAll()
        {
            var clientes = _serviceCliente.GetAll();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public ClienteDTO GetById(int id)
        {
            Cliente cliente = _serviceCliente.GetById(id);
            return _mapper.Map<ClienteDTO>(cliente);
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
            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            _serviceCliente.Update(cliente);
        }
    }
}