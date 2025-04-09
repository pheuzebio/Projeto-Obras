using AgcTelefonicaPH.Data;
using AgcTelefonicaPH.Models;
using AgcTelefonicaPH.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgcTelefonicaPH.Controllers
{
    public class ObraController : Controller
    {
        private readonly IObraRepositorio _obraRepositorio;

        private readonly BancoContext _bancoContext;
        public ObraController(IObraRepositorio obraRepositorio, BancoContext bancoContext)
        {
            _obraRepositorio = obraRepositorio;
            _bancoContext = bancoContext;
        }
        public IActionResult Index()
        {
            List<ObraModel> obras = _obraRepositorio.BuscarAll();

            // Obtém todos os IDs de clientes das obras
            var idsClientes = obras.Select(o => o.idCliente).Distinct().ToList();

            // Busca os contatos correspondentes aos IDs de clientes
            var contatos = _bancoContext.Contactos
                .Where(c => idsClientes.Contains(c.id))
                .ToDictionary(c => c.id, c => c.Cliente ?? "Cliente não encontrado");

            ViewBag.Contatos = contatos; // Dicionário com idCliente -> Nome do Cliente

            return View(obras);
        }
        public IActionResult CriarObra()    
        {
            var obra = new ObraModel();
            ViewBag.Contatos = _bancoContext.Contactos.ToList(); // Lista de contatos do banco
            return View(obra);
        }
        public IActionResult EditarObra(int id)
        {
            ObraModel obra = _obraRepositorio.ListarPorId(id);
            ViewBag.Contatos = _bancoContext.Contactos.ToList();
            return View(obra);
        }
        public IActionResult ApagarConfirmObra(int id)
        {
            ObraModel obra = _obraRepositorio.ListarPorId(id);
            ContactoModel contato = _obraRepositorio.ListarPorIdCliente(obra.idCliente);
            ViewBag.NomeCliente = contato?.Cliente ?? "Cliente não encontrado"; // Nome do cliente ou mensagem padrão
            ViewBag.Contatos = _bancoContext.Contactos.ToList(); // Mantém a lista de contatos, se necessário
            return View(obra);
        }
        public IActionResult Apagar(int id)
        {
            bool apagado = _obraRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult CriarObra(ObraModel obra)
        {
            
            _obraRepositorio.Adicionar(obra);
            TempData["MensagemSucesso"] = "Obra criada com sucesso";
            return RedirectToAction("Index");
                
            
            
        }
        [HttpPost]
        public IActionResult EditarObra(ObraModel obra)
        {
            _obraRepositorio.Atualizar(obra);
            TempData["MensagemSucesso"] = "Contato atualizado com sucesso";
            return RedirectToAction("Index");
        }
    }
}
