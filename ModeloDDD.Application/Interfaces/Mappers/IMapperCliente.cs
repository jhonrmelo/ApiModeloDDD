using ModeloDDD.Application.DTO;
using ModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ModeloDDD.Application.Interfaces.Mappers
{
    public interface IMapperCliente
    {
        Cliente MapperDtoToEntity(ClienteDTO clienteDTO);

        IEnumerable<ClienteDTO> MapperListClientesToDto(IEnumerable<Cliente> clientes);

        ClienteDTO MapperEntityToDto(Cliente cliente);
    }
}