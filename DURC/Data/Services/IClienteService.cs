using DURC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DURC.Data.Services
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetClientePorId(int id);
        bool Update(Cliente cliente);
        bool Delete(int id);
    }
}
