using DURC.Data.Services;
using DURC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DURC.Controllers
{
    [Authorize]
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

       public IActionResult Cadastrar()
        {
            var model = new CadastroClienteViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroClienteViewModel viewModel)
        {
            if (ModelState.IsValid == false)
                return View(viewModel);

            var cliente = new Cliente()
            {
                CPF = viewModel.CPF,
                Nome = viewModel.Nome,
                Telefone = viewModel.Celular,
                DataCadastro = DateTime.Now,
                Enderecos = new List<Endereco>()
                {
                    new Endereco()
                    {
                        Logradouro = viewModel.Logradouro,
                        Numero = viewModel.Numero,
                        Bairro = viewModel.Bairro,
                        Cidade = viewModel.Cidade,
                        Estado = viewModel.Estado
                    }
                }
            };

            var criado = ClienteService.Create(cliente);

            if (criado)
                return RedirectToAction("Listar", "Cliente");

            return StatusCode(500, "Erro ao salvar");
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
