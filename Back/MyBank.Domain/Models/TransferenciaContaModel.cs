using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Models
{
    public class TransferenciaContaModel
    {
        public TransferenciaContaModel(string token, string agenciaOrigem, string numContaOrigem, double valorOrigen, string agenciaDestino, string numContaDestino, double valorDestino)
        {
            Token = token;
            AgenciaOrigem = agenciaOrigem;
            NumContaOrigem = numContaOrigem;
            ValorOrigen = valorOrigen;
            AgenciaDestino = agenciaDestino;
            NumContaDestino = numContaDestino;
            ValorDestino = valorDestino;
        }

        public string Token { get; }
        public string AgenciaOrigem { get; }
        public string NumContaOrigem { get; }
        public double ValorOrigen { get; }
        public string AgenciaDestino { get; }
        public string NumContaDestino { get; }
        public double ValorDestino { get; }
    }

}
