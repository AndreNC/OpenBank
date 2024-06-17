using OpenBank.Entidades;
using OpenBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBank.Repositorios
{
    public class GerenciadorDeContasRepositorio : IGerenciadorDeContasRepositorio, IDisposable
    {
        private BankContext _bankContext;

        public GerenciadorDeContasRepositorio(BankContext bankContext)
        {
            _bankContext = bankContext;

        }

        public void AdicionarCliente(Cliente cliente)
        {
            _bankContext.Add(cliente);

            _bankContext.SaveChanges();
        }

        public Cliente ObterUltimoClienteCadastrado(Cliente cliente)
        {
            var dadosCliente = _bankContext.Clientes.Where(c => c.CPF != null).OrderByDescending(c => c.Id);

            return dadosCliente.FirstOrDefault();
        }

        public void AdicionarDadosDaConta(ContaBancaria contaBancaria)
        {
            _bankContext.Add(contaBancaria);

            _bankContext.SaveChanges();
        }

        public ContaBancaria ObterContaCliente(ContaBancaria conta)
        {
            var dadosContas = _bankContext.Contas.Where(c => c.NumeroConta == conta.NumeroConta && c.Senha == conta.Senha).OrderByDescending(c => c.NumeroConta);
            return dadosContas.FirstOrDefault();

        }

        public void Depositar(ContaBancaria contaBancaria)
        {
            _bankContext.Update(contaBancaria);

            _bankContext.SaveChanges();
        }

        public void Sacar(ContaBancaria contaBancaria)
        {
            _bankContext.Update(contaBancaria);

            _bankContext.SaveChanges();
        }

        public ContaBancaria MostrarExtratoBancario()
        {
            return _bankContext.Contas.FirstOrDefault();
        }

        public void Dispose()
        {
            _bankContext.Dispose();
        }


    }
}
