using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using MyBank.Infra.Shared.Mapper;
using System;
using System.Collections.Generic;


namespace MyBank.Service.Services
{
    public class ContaService : IServiceConta
    {
        private readonly IRepositoryConta _repositoryConta;
        private readonly IRepositoryCliente _repositoryCliente;
        private readonly Random random = new Random(); 
        public ContaService(IRepositoryConta repositoryConta, IRepositoryCliente repositoryCliente)
        {
            _repositoryConta = repositoryConta;
            _repositoryCliente = repositoryCliente;
        }
        public ContaService()
        {

        }

        public ContaModel insert(TokenModel createConta)
        {
            string agencia = "0001";
            string NumConta = GeradorNumeroConta(agencia);
            var conta = new Conta(0, agencia, NumConta);
            conta.Cliente =_repositoryCliente.Get(createConta.token);
            _repositoryConta.Save(conta);
            return conta.ConvertToReturnModel();
        }

        public void delete(DeleteContaModel contaModel)
        {
            var cliente = _repositoryCliente.Get(contaModel.Token);
            if(cliente != null)
            {
                _repositoryConta.Remove(contaModel.Agencia, contaModel.NumConta);
            }
            else
            {
                throw new Exception("Token invalido");
            }
            
        }

        public IEnumerable<ContaModel> recover()
        {
            IEnumerable<Conta> contas = _repositoryConta.Get();
            return contas.ConvertToReturnModel();
        }

        public ContaModel recover(int id)
        {
            var conta = _repositoryConta.Get(id);
            return conta.ConvertToReturnModel(); ;
        }
        private Conta recoverConta(string agencia, string numConta)
        {
            return _repositoryConta.Get(agencia, numConta);
        }

        public virtual void depositar(ConsultaContaModel contaModel)
        {
            Conta conta = recoverConta(contaModel.Agencia, contaModel.NumConta);
            conta.Saldo += contaModel.Valor;
            _repositoryConta.Save(conta);
        }

        public virtual void sacar(ConsultaContaModel contaModel)
        {
            Conta conta = recoverConta(contaModel.Agencia, contaModel.NumConta);
            conta.Saldo -= contaModel.Valor;
            if (conta.Saldo >= 0)
            {
                _repositoryConta.Save(conta);
            }
            else
            {
                throw new Exception("Saldo insuficiente.");
            }


        }

        public virtual void transferir(ConsultaContaModel contaModelOrigin, ConsultaContaModel contaModelDestiny)
        {
            sacar(contaModelOrigin);
            contaModelDestiny.Valor = contaModelOrigin.Valor;
            depositar(contaModelDestiny);
        }

        private string GeradorNumeroConta(string agencia)
        {
            while(true)
            {
                string resp = "";
                int[] array = new int[7];
                for (int i = 0; i < 8; i++)
                {
                    if (i < 7)
                    {
                        array[i] = random.Next(0, 9);
                        resp += array[i].ToString();
                    }
                    else
                    {
                        resp += Verhoeff(array);
                    }
                }
                try
                {
                    var conta = _repositoryConta.Get(agencia, resp);
                    if(conta == null)
                    {
                        return resp;
                    }

                }catch(Exception e)
                {
                    Console.WriteLine(e);
                    return resp;
                }
            }          
        }

        private static int Verhoeff(int[] cadeia)
        {
            int[,] TLOCAL = new int[8,10]{ 
                {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}, 
                {1, 5, 7, 6, 2, 8, 3, 0, 9, 4},
                {5, 8, 0, 3, 7, 9, 6, 1, 4, 2},
                {8, 9, 1, 6, 0, 4, 3, 5, 2, 7},
                {9, 4, 5, 3, 1, 2, 6, 8, 7, 0},
                {4, 2, 8, 6, 5, 7, 3, 9, 0, 1},
                {2, 7, 9, 3, 8, 0, 6, 4, 1, 5},
                {7, 0, 4, 6, 9, 1, 3, 2, 5, 8},
            };

            int[,] TINVER = new int[10, 10]
            {
                {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 0, 6, 7, 8, 9, 5},
                {2, 3, 4, 0, 1, 7, 8, 9, 5, 6},
                {3, 4, 0, 1, 2, 8, 9, 5, 6, 7},
                {4, 0, 1, 2, 3, 9, 5, 6, 7, 8},
                {5, 9, 8, 7, 6, 0, 4, 3, 2, 1},
                {6, 5, 9, 8, 7, 1, 0, 4, 3, 2},
                {7, 6, 5, 9, 8, 2, 1, 0, 4, 3},
                {8, 7, 6, 5, 9, 3, 2, 1, 0, 4},
                {9, 8, 7, 6, 5, 4, 3, 2, 1, 0},
            };
            int[] TDIVER = new int[10] {0, 4, 3, 2, 1, 5, 6, 7, 8, 9};

            int contador = 1;
            int[] INVER = new int[cadeia.Length+1];
            INVER[0] = 0;
            for(int i = cadeia.Length-1; i >= 0; i--)
            {     
                INVER[contador] = cadeia[i];
                contador++;
            }

            int linha = 0;
            int[] inLocal = new int[cadeia.Length+1];
            int[] valorVerificador = new int[cadeia.Length + 2];
            valorVerificador[0] = 0;
            for(int i = 0; i < INVER.Length; i++)
            {
                if(linha > 7)
                {
                    linha = 0;
                }
                inLocal[i] = TLOCAL[linha, INVER[i]];
                valorVerificador[i + 1] = TINVER[valorVerificador[i], inLocal[i]];                
                linha++;
            }
            return TDIVER[valorVerificador[cadeia.Length+1]];
        }
    }
}
