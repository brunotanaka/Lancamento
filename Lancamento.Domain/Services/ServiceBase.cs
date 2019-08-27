using Lancamento.Domain.Entities;
using Lancamento.Domain.Interfaces.Repositories;
using Lancamento.Domain.Interfaces.Services;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lancamento.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : Entity
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> Add(TEntity entity)
            => await _repository.Save(entity);


        public async Task<TEntity> GetBy(FilterDefinition<TEntity> filter)
            => await _repository.GetBy(filter);

        public async Task<IEnumerable<TEntity>> GetListBy(FilterDefinition<TEntity> filter)
            => await _repository.GetListBy(filter);
    }
}
