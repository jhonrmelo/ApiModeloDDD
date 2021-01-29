using ModeloDDD.Application.DTO;

using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        void Add(ProdutoDTO ProdutoDTO);

        void Update(ProdutoDTO ProdutoDTO);

        void Remove(ProdutoDTO ProdutoDTO);

        IEnumerable<ProdutoDTO> GetAll();

        ProdutoDTO GetById(int id);
    }
}
