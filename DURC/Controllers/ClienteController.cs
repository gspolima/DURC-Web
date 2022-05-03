using DURC.Data.Services;
using DURC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DURC.Controllers
{
    public class ClienteController : Controller
    {
        public IClienteService ClienteService { get; set; }

        public ClienteController(IClienteService clienteService)
        {
            this.ClienteService = clienteService;
        }

        public IActionResult Listar()
        {
            var model = ClienteService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var cliente = ClienteService.GetClientePorId(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            var atualizado = ClienteService.Update(cliente);
            if (atualizado)
                return RedirectToAction("Listar", "Cliente");

            return NotFound("Cliente não existe!");
        }

        public IActionResult Deletar(int id)
        {
            var deletado = ClienteService.Delete(id);

            if (deletado)
                return RedirectToAction("Listar", "Cliente");
            
            return NotFound("Cliente já foi excluído!");
        }
    }
}
