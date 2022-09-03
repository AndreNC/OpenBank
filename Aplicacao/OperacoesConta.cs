using OpenBank.Entidades;
using OpenBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBank.Aplicacao
{
    public class OperacoesConta : IOperacoesConta
    {
        private IGerenciadorDeContasRepositorio _gerenciadorDeContasRepositorio;

        public OperacoesConta(IGerenciadorDeContasRepositorio gerenciadorDeContasRepositorio)
        {
            _gerenciadorDeContasRepositorio = gerenciadorDeContasRepositorio; 
        }

        public Cliente CadastrarCliente(string nome, string cpf)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = nome;
            cliente.CPF = cpf;

            _gerenciadorDeContasRepositorio.AdicionarCliente(cliente);

            return cliente;
        }

        public ContaBancaria CadastrarConta(int agencia, int conta, string tipo, string senha, Cliente cliente)
        {
            ContaBancaria contaCliente = new ContaBancaria();
            Cliente clienteCadastrado = BuscarUltimoCliente(cliente);

            contaCliente.Agencia = agencia;
            contaCliente.NumeroConta = conta;
            contaCliente.TipoDeConta = tipo;
            contaCliente.Titular = clienteCadastrado;
            contaCliente.Senha = senha;

            try
            {
                if (clienteCadastrado.CPF != null)
                    _gerenciadorDeContasRepositorio.AdicionarDadosDaConta(contaCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Não existe cliente cadastrado para vincular a essa conta", ex);

            }

            return contaCliente;
        }

        public void Depositar(ContaBancaria contaBancaria)
        {
            ContaBancaria contaCliente = BuscarContaBancaria(contaBancaria);

            try
            {
                if (contaCliente.NumeroConta == contaBancaria.NumeroConta && contaCliente.Senha == contaBancaria.Senha)
                {

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Dados de conta inválidos", ex);
            }
            if (contaBancaria.Saldo <= 0)
            {
                throw new ArgumentException("Valor inválido para depósito.", nameof(contaBancaria.Saldo));
            }

            contaCliente.Saldo += contaBancaria.Saldo;

            _gerenciadorDeContasRepositorio.Depositar(contaCliente);

        }

        public void Sacar(ContaBancaria contaBancaria)
        {
            ContaBancaria contaCliente = BuscarContaBancaria(contaBancaria);

            try
            {
                if (contaCliente.NumeroConta == contaBancaria.NumeroConta && contaCliente.Senha == contaBancaria.Senha)
                {

                }
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Dados de conta inválidos.", ex);
            }

            if (contaBancaria.Saldo <= 0)
            {
                throw new ArgumentException("Valor inválido para saque.", nameof(contaBancaria.Saldo));
            }

            if (contaCliente.Saldo < contaBancaria.Saldo)
            {
                throw new ArgumentException("Não há saldo suficiente em conta.", nameof(contaCliente.Saldo));

            }

            contaCliente.Saldo -= contaBancaria.Saldo;

            _gerenciadorDeContasRepositorio.Sacar(contaCliente);

        }

        public ContaBancaria MostrarExtrato(ContaBancaria contaBancaria)
        {
            ContaBancaria contaCliente = BuscarContaBancaria(contaBancaria);
            try
            {
                if (contaCliente.NumeroConta == contaBancaria.NumeroConta && contaCliente.Senha == contaBancaria.Senha)
                {

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Dados de conta inválidos", ex);
            }
            _gerenciadorDeContasRepositorio.MostrarExtratoBancario();

            return contaCliente;

        }

        private Cliente BuscarUltimoCliente(Cliente cliente)
        {
            cliente = _gerenciadorDeContasRepositorio.ObterUltimoClienteCadastrado(cliente);


            return cliente;
        }

        private ContaBancaria BuscarContaBancaria(ContaBancaria numeroConta)
        {
            numeroConta = _gerenciadorDeContasRepositorio.ObterContaCliente(numeroConta);

            return numeroConta;
        }
    }
}
