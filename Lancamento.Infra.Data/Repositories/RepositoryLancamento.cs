using Lancamento.Domain.Interfaces.Repositories;
using MongoDB.Driver;

namespace Lancamento.Infra.Data.Repositories
{
    public class RepositoryLancamento : RepositoryBase<Domain.Entities.Lancamento>, IRepositoryLancamento
    {
        public RepositoryLancamento(IMongoDatabase mongoDatabase) 
            : base(mongoDatabase)
        {

        }
    }
}
