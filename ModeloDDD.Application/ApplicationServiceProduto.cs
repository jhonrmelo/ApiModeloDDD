using ModeloDDD.Application.DTO;
using ModeloDDD.Application.Interfaces;
using ModeloDDD.Application.Interfaces.Mappers;
using ModeloDDD.Domain.Core.Interfaces.Services;
using ModeloDDD.Domain.Entities;
using ModeloDDD.Application.Exceptions;

using System.Collections.Generic;

namespace ModeloDDD.Application
{
    public class ApplicationServiceProduto : IApplicationServiceProduto
    {
        private readonly IServiceProduto _serviceProduto;
        private readonly IMapperProduto _mapperProduto;

        public ApplicationServiceProduto(IServiceProduto serviceProduto, IMapperProduto imapperProduto)
        {
            _mapperProduto = imapperProduto;
            _serviceProduto = serviceProduto;
        }

        public void Add(ProdutoDTO ProdutoDTO)
        {
            Produto produto = _mapperProduto.MapperDtoToEntity(ProdutoDTO);
            _serviceProduto.Add(produto);
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            IEnumerable<Produto> produtos = _serviceProduto.GetAll();
            return _mapperProduto.ListProdutoTODto(produtos);
        }

        public ProdutoDTO GetById(int id)
        {
            Produto produto = _serviceProduto.GetById(id);
            return _mapperProduto.MapperEntityToDto(produto);
        }

        public void Remove(int id)
        {
            Produto produto = _serviceProduto.GetById(id);

            if (produto is null)
                throw new NotFoundException("Produto não encontrado");

            _serviceProduto.Remove(produto);
        }

        public void Update(ProdutoDTO ProdutoDTO)
        {
            Produto produto = _mapperProduto.MapperDtoToEntity(ProdutoDTO);
            _serviceProduto.Update(produto);
        }
    }
}