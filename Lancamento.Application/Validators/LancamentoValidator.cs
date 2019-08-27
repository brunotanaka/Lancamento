using FluentValidation;
using Lancamento.Application.Models;

namespace Lancamento.Application.Validators
{
    public class LancamentoValidator : AbstractValidator<LancamentoViewModel>
    {
        public LancamentoValidator()
        {
            RuleFor(x => x.ContaDestino).GreaterThan(0).WithMessage("Conta Destino precisa válida");
            RuleFor(x => x.ContaOrigem).GreaterThan(0).WithMessage("Conta Origem precisa válida");
            RuleFor(x => x.Valor).GreaterThan(0).WithMessage("Valor precisa ser maior que 0.");
        }
    }
}
