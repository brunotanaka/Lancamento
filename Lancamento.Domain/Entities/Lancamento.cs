using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Lancamento.Domain.Entities
{
    public class Lancamento : Entity
    {
        [BsonElement("ContaOrigem")]
        public ContaCorrente ContaOrigem { get; set; }

        [BsonElement("ContaDestino")]
        public ContaCorrente ContaDestino { get; set; }

        [BsonElement("Valor")]
        public decimal Valor { get; set; }

        [BsonElement("Data")]
        public DateTime Data { get; set; }

        public Lancamento()
        {

        }

        public Lancamento(int contaOrigem, int contaDestino, decimal valor)
            : this(new ContaCorrente() { Numero = contaOrigem }, new ContaCorrente() { Numero = contaDestino }, valor)
        {

        }

        public Lancamento(ContaCorrente contaOrigem, ContaCorrente contaDestino, decimal valor)
        {
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
            Data = DateTime.Now;
        }
    }
}
