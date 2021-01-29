using ModeloDDD.Domain.Core.Interfaces.Repositories;
using ModeloDDD.Domain.Entities;

namespace ModeloDDD.Infra.Data.Repository
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        private readonly SqlContext _sqlContext;
        public RepositoryProduto(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
