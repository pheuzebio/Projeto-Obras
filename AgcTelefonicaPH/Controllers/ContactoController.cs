﻿using AgcTelefonicaPH.Models;
using AgcTelefonicaPH.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AgcTelefonicaPH.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IContactoRepositorio _contactoRepositorio;

        public ContactoController(IContactoRepositorio contactoRepositorio)
        {
            _contactoRepositorio = contactoRepositorio; 
        }
        public IActionResult Index()
        {
            List<ContactoModel> contactos = _contactoRepositorio.BuscarAll();
            return View(contactos);
        }

        public IActionResult CriarContacto()
        {

            return View();
        }

        public IActionResult EditarContacto(int id)
        {
            ContactoModel contacto = _contactoRepositorio.ListarPorId(id);
            return View(contacto);
        }

        public IActionResult ApagarConfirm(int id)
        {
            ContactoModel contacto = _contactoRepositorio.ListarPorId(id);
            return View(contacto);
        }

        public IActionResult Apagar(int id) 
        {
            try
            {
                bool apagado = _contactoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "erro ao apagar o contato, tente novamente";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"erro ao apagar o contato, tente novamente, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CriarContacto(ContactoModel contacto, IFormFile imagem) 
        {
           
                    _contactoRepositorio.Adicionar(contacto, imagem);
                    TempData["MensagemSucesso"] = "Contato registado com sucesso";
                    return RedirectToAction("Index");
                
        }

        [HttpPost]
        public IActionResult EditarContacto(ContactoModel contacto, IFormFile imagem)
        {
                    _contactoRepositorio.Atualizar(contacto, imagem);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
               
        }
    }
}
