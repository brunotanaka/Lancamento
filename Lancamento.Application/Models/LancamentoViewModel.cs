namespace Lancamento.Application.Models
{
    public class LancamentoViewModel
    {
        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        public decimal Valor { get; set; }

        public Domain.Entities.Lancamento ToEntity()
        {
            return new Domain.Entities.Lancamento(this.ContaOrigem, this.ContaDestino, this.Valor);
        }
    }
}
