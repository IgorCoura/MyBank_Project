namespace MyBank.Domain.Models
{
    public class ContaModel
    {
        public ContaModel(int id, string agencia, string numConta, double saldo)
        {
            Id = id;
            Agencia = agencia;
            NumConta = numConta;
            Saldo = saldo;
        }

        public int Id { get; set; }
        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public double Saldo { get; set; }
    }
}
