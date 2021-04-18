using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Models
{
    public class TransferenciaContaModel
    {
        public TransferenciaContaModel(string token, string agenciaOrigem, string numContaOrigem, string agenciaDestino, string numContaDestino, double valor)
        {
            Token = token;
            AgenciaOrigem = agenciaOrigem;
            NumContaOrigem = numContaOrigem;
            AgenciaDestino = agenciaDestino;
            NumContaDestino = numContaDestino;
            Valor = valor;
        }

        public string Token { get; set; }
        public string AgenciaOrigem { get; set; }
        public string NumContaOrigem { get; set; }
        public string AgenciaDestino { get; set; }
        public string NumContaDestino { get; set; }
        public double Valor { get; set; }
    }

}
