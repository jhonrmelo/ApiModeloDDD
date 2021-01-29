using ModeloDDD.Application.DTO;
using ModeloDDD.Domain.Entities;
using System.Linq;
using System.Collections.Generic;
using ModeloDDD.Application.Interfaces.Mappers;

namespace ModeloDDD.Application.Mappers
{
    public class MapperProduto : IMapperProduto
    {
        public Produto MapperDtoToEntity(ProdutoDTO produtoDTO)
        {
            return new Produto()
            {
                Id = produtoDTO.Id.Value,
                Nome = produtoDTO.Nome,
                Valor = produtoDTO.Valor
            };
        }

        public IEnumerable<ProdutoDTO> ListProdutoTODto(IEnumerable<Produto> produtos)
        {
            return produtos.Select(produto => new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Valor = produto.Valor
            });
        }

        public ProdutoDTO MapperEntityToDto(Produto produto)
        {
            return new ProdutoDTO()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Valor = produto.Valor
            };
        }
    }
}