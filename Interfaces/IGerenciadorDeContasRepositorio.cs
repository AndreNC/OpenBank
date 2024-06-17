using OpenBank.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBank.Interfaces
{
    public interface IGerenciadorDeContasRepositorio
    {
        void AdicionarCliente(Cliente cliente);

        void AdicionarDadosDaConta(ContaBancaria contaBancaria);

        Cliente ObterUltimoClienteCadastrado(Cliente cliente);

        void Depositar(ContaBancaria contaBancaria);

        void Sacar(ContaBancaria contaBancaria);

        ContaBancaria ObterContaCliente(ContaBancaria conta);

        ContaBancaria MostrarExtratoBancario();
    }
}
