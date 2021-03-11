using MyBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Models
{
    public class TransferContaModel
    {
        public TransferContaModel(Cliente cliente, int agencia, int numConta)
        {
            Cliente = cliente;
            Agencia = agencia;
            NumConta = numConta;
        }

        public Cliente Cliente { get; set; }
        public int Agencia { get; set; }
        public int NumConta { get; set; }
    }
}
