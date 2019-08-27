using Lancamento.Domain.Entities;
using Lancamento.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lancamento.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        private readonly IMongoDatabase _mongoDatabase;

        public RepositoryBase(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task<TEntity> GetBy(FilterDefinition<TEntity> filter) => await _mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name).Find(filter).FirstOrDefaultAsync();

        public async Task<IEnumerable<TEntity>> GetListBy(FilterDefinition<TEntity> filter) => await _mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name).Find(filter).ToListAsync();

        public async Task<TEntity> Save(TEntity entity)
        {
            var collection = _mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);

            await collection.ReplaceOneAsync(x => x.Id == entity.Id, entity, new UpdateOptions
            {
                IsUpsert = true,
            });

            return entity;
        }
    }
}
