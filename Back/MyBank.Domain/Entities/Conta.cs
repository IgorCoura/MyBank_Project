using System.ComponentModel.DataAnnotations.Schema;

namespace MyBank.Domain.Entities
{
    public class Conta: BaseEntity<int>
    {
        private Conta() { }
        public Conta(int id, int agencia, int numConta): base(id)
        {
            Agencia = agencia;
            NumConta = numConta;
        }
        private double saldo = 0;     
        public int Agencia { get; set; }
        public int NumConta { get; set; }
        public double Saldo { get => saldo; set => saldo = value; }
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

    }
}
