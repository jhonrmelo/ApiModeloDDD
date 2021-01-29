using ModeloDDD.Application.DTO;
using ModeloDDD.Domain.Entities;

using System.Collections.Generic;

namespace ModeloDDD.Application.Interfaces.Mappers
{
    public interface IMapperProduto
    {
        Produto MapperDtoToEntity(ProdutoDTO produtoDTO);

        IEnumerable<ProdutoDTO> ListProdutoTODto(IEnumerable<Produto> produtos);

        ProdutoDTO MapperEntityToDto(Produto produto);
    }
}