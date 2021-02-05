using ModeloDDD.Application.DTO;
using System.Collections.Generic;

namespace ModeloDDD.Application.Extensions
{
    public static class ProdutoExtensions
    {
        public static void CalculaValorMaximoDeVenda(this ProdutoDTO produtoDTO)
        {
            produtoDTO.ValorMaximoVenda = produtoDTO.Valor * produtoDTO.Quantidade;
        }

        public static void CalculaValorMaximoDeVenda(this IEnumerable<ProdutoDTO> produtosDto)
        {
            foreach (ProdutoDTO produtoDTO in produtosDto)
            {
                produtoDTO.ValorMaximoVenda = produtoDTO.Valor * produtoDTO.Quantidade;
            }
        }
    }
}