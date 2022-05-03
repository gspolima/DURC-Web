using DURC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DURC.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Telefone)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.DataCadastro)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Cliente>()
                .HasData(
                    new List<Cliente>()
                    {
                        new Cliente()
                        {
                            Id = 1,
                            Nome = "Gustavo Sampaio",
                            CPF = "08277083351",
                            Telefone = "85989724718",
                            DataCadastro = DateTime.Now
                        },
                        new Cliente()
                        {
                            Id = 2,
                            Nome = "Ana Luna Ribeiro",
                            CPF = "08951343499",
                            Telefone = "81995296198",
                            DataCadastro = DateTime.Now
                        },
                        new Cliente()
                        {
                            Id = 3,
                            Nome = "Henrique Benedito Cavalcanti",
                            CPF = "95022974584",
                            Telefone = "79983175583",
                            DataCadastro = DateTime.Now,
                            Enderecos = new List<Endereco>()
                            {
                            }
                        },
                        new Cliente()
                        {
                            Id = 4,
                            Nome = "Diego Sérgio Aragão",
                            CPF = "67836345157",
                            Telefone = "98985840187",
                            DataCadastro = DateTime.Now
                        }
                    }
                );

            modelBuilder.Entity<Endereco>()
                .Property(c => c.Logradouro)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Endereco>()
                .Property(c => c.Numero)
                .IsRequired();

            modelBuilder.Entity<Endereco>()
                .Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Endereco>()
                .Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Endereco>()
                .Property(c => c.Estado)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Endereco>()
                .Property(c => c.Complemento)
                .HasMaxLength(50);

            modelBuilder.Entity<Endereco>()
                .Property(c => c.CEP)
                .HasMaxLength(8);

            modelBuilder.Entity<Endereco>()
                .HasData(new List<Endereco>()
                    {
                        new Endereco()
                        {
                            Id = 1,
                            Logradouro = "Rua 8",
                            Numero = 1176,
                            Bairro = "Mondubim",
                            Cidade = "Fortaleza",
                            Estado = "Ceará",
                            CEP = "60767680",
                            ClienteId = 1
                        },
                        new Endereco()
                        {
                            Id = 2,
                            Logradouro = "Rua Aripibu",
                            Numero = 823,
                            Bairro = "Mangabeira",
                            Cidade = "Recife",
                            Estado = "Pernambuco",
                            CEP = "52110450",
                            ClienteId = 2
                        },
                        new Endereco()
                        {
                            Id = 3,
                            Logradouro = "Avenida Ivo do Prado",
                            Numero = 545,
                            Bairro = "Centro",
                            Cidade = "Aracaju",
                            Estado = "Sergipe",
                            CEP = "49010050",
                            ClienteId = 3
                        },
                        new Endereco()
                        {
                            Id = 4,
                            Logradouro = "Praça Presidente Dutra",
                            Numero = 571,
                            Bairro = "Fátima",
                            Cidade = "São Luís",
                            Estado = "Maranhão",
                            CEP = "65031390",
                            ClienteId = 4
                        }
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
