using ModeloDDD.Domain.Core.Interfaces.Repositories;
using ModeloDDD.Domain.Core.Interfaces.Services;
using ModeloDDD.Domain.Entities;

namespace ModeloDDD.Domain.Services
{
    public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
    {
        private readonly IRepositoryProduto _repositoryProduto;

        public ServiceProduto(IRepositoryProduto repository) : base(repository)
        {
            _repositoryProduto = repository;
        }
    }
}
