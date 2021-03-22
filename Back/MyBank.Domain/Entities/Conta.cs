using System.ComponentModel.DataAnnotations.Schema;

namespace MyBank.Domain.Entities
{
    public class Conta: BaseEntity<int>
    {
        private Conta() { }
        public Conta(int id, string agencia, string numConta): base(id)
        {
            Agencia = agencia;
            NumConta = numConta;
        }
        private double saldo = 0;     
        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public double Saldo { get => saldo; set => saldo = value; }
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

    }
}
