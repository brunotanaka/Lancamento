using Lancamento.Domain.Interfaces.Repositories;
using Lancamento.Domain.Interfaces.Services;

namespace Lancamento.Domain.Services
{
    public class LancamentoService : ServiceBase<Entities.Lancamento>, ILancamentoService
    {
        private readonly IRepositoryLancamento _repository;

        public LancamentoService(IRepositoryLancamento repository) 
            : base(repository)
        {
            _repository = repository;
        }
    }
}
