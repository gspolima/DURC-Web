using DURC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DURC.Data.Services
{
    public class ClienteService : IClienteService
    {
        public ApplicationDbContext DbContext { get; set; }

        public ClienteService(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public IEnumerable<Cliente> GetAll()
        {
            var clientes = DbContext.Clientes
                .Include(c => c.Enderecos)
                .OrderBy(c => c.Id)
                .ToList();

            foreach (var cliente in clientes)
            {
                var parte1 = string.Concat(cliente.CPF.Substring(0, 3).Append('.'));
                var parte2 = string.Concat(cliente.CPF.Substring(3, 3).Append('.'));
                var parte3 = string.Concat(cliente.CPF.Substring(6, 3).Append('-'));
                var parte4 = string.Concat(cliente.CPF.Substring(9, 2));
                var cpf = string.Concat(parte1, parte2, parte3, parte4);

                cliente.CPF = cpf;

                var tel1 = string.Concat(cliente.Telefone.Substring(0, 2).Append(')'));
                var tel2 = string.Concat(cliente.Telefone.Substring(2, 5).Append('-'));
                var tel3 = string.Concat(cliente.Telefone.Substring(7));

                var telefone = string.Concat(tel1, tel2, tel3).Prepend('(');
                cliente.Telefone = string.Concat(telefone);
            }

            return clientes;
        }

        public Cliente GetClientePorId(int id)
        {
            var cliente = DbContext.Clientes
                .Include(c => c.Enderecos)
                .Where(c => c.Id == id)
                .FirstOrDefault();

            return cliente;
        }

        public bool Create(Cliente cliente)
        {
            DbContext.Clientes.Add(cliente);
            return DbContext.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Cliente cliente)
        {
            var existe = DbContext.Clientes
                .Any(c => c.Id == cliente.Id);

            if (existe)
            {
                DbContext.Clientes.Update(cliente);
                return DbContext.SaveChanges() > 0 ? true : false;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var existe = DbContext.Clientes
                .Any(c => c.Id == id);

            if (existe)
            {
                var cliente = DbContext.Clientes
                    .Where(c => c.Id == id)
                    .FirstOrDefault();

                DbContext.Clientes.Remove(cliente);
                return DbContext.SaveChanges() > 0 ? true : false;
            }

            return false;
        }
    }
}
