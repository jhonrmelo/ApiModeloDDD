using ModeloDDD.Application.DTO;

using System.Collections.Generic;

namespace ModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceCliente
    {
        void Add(ClienteDTO clienteDTO);

        void Update(ClienteDTO clienteDTO);

        void Remove(ClienteDTO clienteDTO);

        IEnumerable<ClienteDTO> GetAll();

        ClienteDTO GetById(int id);
    }
}