using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBank.Entidades
{
    public class ContaBancaria
    {
        public int Id { get; set; }
        public int Agencia { get; set; }
        public int NumeroConta { get; set; }
        public double Saldo { get; set; }
        public string TipoDeConta { get; set; }
        public Cliente Titular { get; set; }
        public string Senha { get; set; }

    }
}
