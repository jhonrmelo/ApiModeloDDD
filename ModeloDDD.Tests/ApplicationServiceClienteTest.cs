using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloDDD.Application;
using ModeloDDD.Domain.Core.Interfaces.Services;
using FluentAssertions;
using Moq;
using ModeloDDD.Domain.Entities;
using System;
using ModeloDDD.Application.Exceptions;
using AutoMapper;
using ModeloDDD.Application.Factory;

namespace ModeloDDD.Tests
{
    [TestClass]
    public class ApplicationServiceClienteTest
    {
        private ApplicationServiceCliente _applicationServiceCliente;
        private Mock<IServiceCliente> _serviceClienteMock;
        private IMapper _mapper;

        public ApplicationServiceClienteTest()
        {
            if (_mapper is null)
                _mapper = AutoMapperFactory.CreaterAutoMapper();

            _serviceClienteMock = new Mock<IServiceCliente>();
            _applicationServiceCliente = new ApplicationServiceCliente(_serviceClienteMock.Object, _mapper);
        }

        [TestMethod]
        public void TentaRemoverClienteNulo()
        {
            _serviceClienteMock.Setup(x => x.GetById(It.IsAny<int>())).Returns<Cliente>(null);

            Action act = () => _applicationServiceCliente.Remove(22);

            act.Should().Throw<NotFoundException>().Where(e => e.Message == "A informação passada para a deleção não existe no banco de dados.");

        }

        [TestMethod]
        public void RemoveCliente()
        {
            Cliente clienteMock = new Cliente()
            {
                Nome = "Jonathan",
                Sobrenome = "Melo",
                IsActive = true,
                Email = "Jonathan@teste",
                DataCadastro = DateTime.Now,
                Id = 13
            };
            _serviceClienteMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(clienteMock);

            _applicationServiceCliente.Remove(13);

            _serviceClienteMock.Verify(v => v.Remove(It.IsAny<Cliente>()), Times.Exactly(1));
        }

    }
}