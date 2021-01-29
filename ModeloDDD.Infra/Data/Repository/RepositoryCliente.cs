using ModeloDDD.Domain.Core.Interfaces.Repositories;
using ModeloDDD.Domain.Entities;

namespace ModeloDDD.Infra.Data.Repository
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        private SqlContext _sqlContext;

        public RepositoryCliente(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}