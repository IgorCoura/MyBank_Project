namespace MyBank.Domain.Models
{
    public class CreateClienteModel
    {
        public CreateClienteModel(string nome, string cpf, string dataNascimento, string senha)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Senha = senha;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public string Senha { get; set; }

    }
}
