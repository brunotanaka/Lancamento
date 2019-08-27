using Lancamento.Domain.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lancamento.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : Entity
    {
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetListBy(FilterDefinition<TEntity> filter);
        Task<TEntity> GetBy(FilterDefinition<TEntity> filter);
    }
}
