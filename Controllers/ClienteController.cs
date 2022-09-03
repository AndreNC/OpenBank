using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenBank.Entidades;
using OpenBank.Interfaces;
using OpenBank.Repositorios;
using OpenBank.ViewModel;


namespace OpenBank.Controllers
{
    [Route("Cliente/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IGerenciadorDeContasRepositorio _gerenciadorDeContasRepositorio;
        private readonly IOperacoesConta _operacoesConta;
        private readonly BankContext _bankContext;

        public ClienteController(IGerenciadorDeContasRepositorio gerenciadorDeContas, IOperacoesConta operacoesConta,  BankContext bankContext)
        {
            _gerenciadorDeContasRepositorio = gerenciadorDeContas;
            _operacoesConta = operacoesConta;
            _bankContext = bankContext;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteView)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = clienteView.Nome;
            cliente.CPF = clienteView.CPF;

            var resultado = _operacoesConta.CadastrarCliente(cliente.Nome, cliente.CPF);
            await _bankContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}