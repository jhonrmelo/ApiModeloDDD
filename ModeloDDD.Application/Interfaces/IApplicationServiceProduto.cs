using ModeloDDD.Application.DTO;

using System.Collections.Generic;

namespace ModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        void Add(ProdutoDTO ProdutoDTO);

        void Update(ProdutoDTO ProdutoDTO);

        void Remove(int id);

        IEnumerable<ProdutoDTO> GetAll();

        ProdutoDTO GetById(int id);
    }
}