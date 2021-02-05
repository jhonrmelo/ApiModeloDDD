using AutoMapper;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ModeloDDD.Application;
using ModeloDDD.Application.DTO;
using ModeloDDD.Application.Exceptions;
using ModeloDDD.Application.Factory;
using ModeloDDD.Domain.Core.Interfaces.Services;
using ModeloDDD.Domain.Entities;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ModeloDDD.Tests
{
    [TestClass]
    public class ApplicationServiceProdutoTest
    {
        private Mock<IServiceProduto> _serviceProdutoMock;
        private ApplicationServiceProduto ApplicationServiceProduto;
        private IMapper _mapper;

        public ApplicationServiceProdutoTest()
        {
            if (_mapper is null)
            {
                _mapper = AutoMapperFactory.CreaterAutoMapper();
            }
            _serviceProdutoMock = new Mock<IServiceProduto>();
            ApplicationServiceProduto = new ApplicationServiceProduto(_serviceProdutoMock.Object, _mapper);
        }

        [TestMethod]
        public void RemoveProdutoNulo()
        {
            _serviceProdutoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns<Produto>(null);

            Action act = () => ApplicationServiceProduto.Remove(35);

            act.Should().Throw<NotFoundException>().Where(e => e.Message == "Produto não encontrado");
        }

        [TestMethod]
        public void RemoveProdutoComSucesso()
        {
            Produto produtoMock = new Produto()
            {
                Nome = "PC",
                IsDisponivel = true,
                Quantidade = 3,
                Valor = 35.50M,
                Id = 10
            };

            _serviceProdutoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(produtoMock);

            ApplicationServiceProduto.Remove(10);

            _serviceProdutoMock.Verify(v => v.Remove(It.IsAny<Produto>()), Times.Exactly(1));
        }

        [TestMethod]
        public void GetByIdValorDeVendaCorreto()
        {
            Produto produtoMock = new Produto()
            {
                Nome = "PC",
                IsDisponivel = true,
                Quantidade = 10,
                Valor = 40,
                Id = 10
            };

            ProdutoDTO produtoDTOMock = new ProdutoDTO()
            {
                Nome = "PC",
                Quantidade = 10,
                Valor = 40,
                Id = 10,
            };

            _serviceProdutoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(produtoMock);

            var produtoDTO = ApplicationServiceProduto.GetById(10);

            produtoDTO.Should().NotBeNull();
            produtoDTO.ValorMaximoVenda.Should().Be(400, because: "A quantidade é 10 e o valor do item é 400");
        }

        [TestMethod]
        public void GetAllProdutosValorMaximoDeVendaCorreto()
        {
            _serviceProdutoMock.Setup(x => x.GetAll()).Returns(_getProdutosMock());

            var produtosDTO = ApplicationServiceProduto.GetAll();

            produtosDTO.Should().HaveCount(2);
            produtosDTO.Sum(p => p.ValorMaximoVenda).Should().Be(65000M);
        }

        #region Métodos privados para mock

        private IEnumerable<Produto> _getProdutosMock()
        {
            IEnumerable<Produto> produtos = new List<Produto>() {
                new Produto()
                {
                    Id = 10,
                    IsDisponivel = true,
                    Nome = "Maquina de Lavar",
                    Quantidade = 50,
                    Valor = 1000
            },
                new Produto()
                {
                    Id = 15,
                    IsDisponivel = true,
                    Nome = "Celular",
                    Quantidade = 10,
                    Valor = 1500
            }
            };
            return produtos;
        }

        private IEnumerable<ProdutoDTO> _getProdutosDTOMock()
        {
            IEnumerable<ProdutoDTO> produtos = new List<ProdutoDTO>() {
                new ProdutoDTO()
                {
                    Id = 10,
                    Nome = "Maquina de Lavar",
                    Quantidade = 50,
                    Valor = 1000
            },
                new ProdutoDTO()
                {
                    Id = 15,
                    Nome = "Celular",
                    Quantidade = 10,
                    Valor = 1500
            }
            };
            return produtos;
        }

        #endregion Métodos privados para mock
    }
}