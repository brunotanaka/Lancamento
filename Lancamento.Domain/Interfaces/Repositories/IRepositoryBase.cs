using Lancamento.Domain.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lancamento.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<TEntity> Save(TEntity entity);
        Task<IEnumerable<TEntity>> GetListBy(FilterDefinition<TEntity> filter);
        Task<TEntity> GetBy(FilterDefinition<TEntity> filter);
    }
}
