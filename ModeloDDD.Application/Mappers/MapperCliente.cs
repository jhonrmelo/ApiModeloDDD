using ModeloDDD.Application.DTO;
using ModeloDDD.Application.Interfaces.Mappers;
using ModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModeloDDD.Application.Mappersr
{
    public class MapperCliente : IMapperCliente
    {
        IEnumerable<ClienteDTO> clientesDTO = new List<ClienteDTO>();

        public Cliente MapperDtoToEntity(ClienteDTO clienteDTO)
        {
            return new Cliente()
            {
                Id = clienteDTO.Id.Value,
                Nome = clienteDTO.Nome,
                Sobrenome = clienteDTO.SobreNome,
                Email = clienteDTO.Email

            };
        }

        public IEnumerable<ClienteDTO> MapperListClientesToDto(IEnumerable<Cliente> clientes)
        {
            var dto = clientes.Select(cliente =>
                new ClienteDTO
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    SobreNome = cliente.Sobrenome
                });

            return dto;
        }


        public ClienteDTO MapperEntityToDto(Cliente cliente)
        {
            return new ClienteDTO()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                SobreNome = cliente.Sobrenome,
                Email = cliente.Email
            };
        }
    }
}