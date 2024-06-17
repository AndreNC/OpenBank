using Microsoft.EntityFrameworkCore;
using OpenBank.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBank.Repositorios
{
    public class BankContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContaBancaria> Contas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContaBancaria>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = desktop-qanj4k9; Initial Catalog = Open_Bank; Integrated Security = true;");
        }
    }
}
