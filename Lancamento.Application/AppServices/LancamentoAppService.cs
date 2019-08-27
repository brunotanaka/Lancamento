using Lancamento.Domain.Interfaces.AppServices;
using Lancamento.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Lancamento.Application.AppServices
{
    public class LancamentoAppService : ILancamentoAppService
    {
        private readonly ILancamentoService _lancamentoService;

        public LancamentoAppService(ILancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        public async Task<Domain.Entities.Lancamento> Add(Domain.Entities.Lancamento lancamento)
            => await _lancamentoService.Add(lancamento);
    }
}
