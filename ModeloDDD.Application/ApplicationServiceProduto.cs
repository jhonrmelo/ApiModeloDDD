using AutoMapper;

using ModeloDDD.Application.DTO;
using ModeloDDD.Application.Exceptions;
using ModeloDDD.Application.Extensions;
using ModeloDDD.Application.Interfaces;
using ModeloDDD.Domain.Core.Interfaces.Services;
using ModeloDDD.Domain.Entities;

using System.Collections.Generic;

namespace ModeloDDD.Application
{
    public class ApplicationServiceProduto : IApplicationServiceProduto
    {
        private readonly IServiceProduto _serviceProduto;
        private readonly IMapper _mapper;

        public ApplicationServiceProduto(IServiceProduto serviceProduto, IMapper mapper)
        {
            _serviceProduto = serviceProduto;
            _mapper = mapper;
        }

        public void Add(ProdutoDTO ProdutoDTO)
        {
            Produto produto = _mapper.Map<Produto>(ProdutoDTO);
            _serviceProduto.Add(produto);
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            IEnumerable<Produto> produtos = _serviceProduto.GetAll();
            IEnumerable<ProdutoDTO> produtosDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
            produtosDTO.CalculaValorMaximoDeVenda();
            return produtosDTO;
        }

        public ProdutoDTO GetById(int id)
        {
            Produto produto = _serviceProduto.GetById(id);

            if (produto is null)
                throw new NotFoundException("Produto não encontrado");

            ProdutoDTO produtoDTO = _mapper.Map<ProdutoDTO>(produto); ;
            produtoDTO.CalculaValorMaximoDeVenda();
            return produtoDTO;
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
            Produto produto = _mapper.Map<Produto>(ProdutoDTO);
            _serviceProduto.Update(produto);
        }
    }
}