using Lancamento.Domain.Entities;
using System.Threading.Tasks;

namespace Lancamento.Domain.Interfaces.AppServices
{
    public interface IAppServiceBase<TEntity> where TEntity : Entity
    {
        Task<TEntity> Add(TEntity entity);
    }
}
