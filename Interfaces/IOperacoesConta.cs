using OpenBank.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBank.Interfaces
{
    public interface IOperacoesConta
    {
        Cliente CadastrarCliente(string nome, string cpf);

        ContaBancaria CadastrarConta(int agencia, int conta, string tipo, string senha, Cliente cliente);

        void Depositar(ContaBancaria contaBancaria);

        void Sacar(ContaBancaria contaBancaria);

        ContaBancaria MostrarExtrato(ContaBancaria contaBancaria);
    }
}
