using ModeloDDD.Domain.Core.Interfaces.Repositories;
using ModeloDDD.Domain.Core.Interfaces.Services;
using ModeloDDD.Domain.Entities;

namespace ModeloDDD.Domain.Services
{
    public class ServiceCliente : ServiceBase<Cliente>, IServiceCliente
    {
        private readonly IRepositoryCliente _repository;
        public ServiceCliente(IRepositoryCliente repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
