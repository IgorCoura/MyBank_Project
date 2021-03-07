using MyBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Models
{
    public class ReturnContaModel
    {
        public ReturnContaModel(int id, Cliente cliente, int agencia, int numConta)
        {
            Id = id;
            Cliente = cliente;
            Agencia = agencia;
            NumConta = numConta;
        }

        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public int Agencia { get; set; }
        public int NumConta { get; set; }
    }
}
