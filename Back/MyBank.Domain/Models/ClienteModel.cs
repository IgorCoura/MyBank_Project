namespace MyBank.Domain.Models
{
    public class ClienteModel
    {
        public ClienteModel(int id, string nome, string cpf, string dataNascimento)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }


    }
}
