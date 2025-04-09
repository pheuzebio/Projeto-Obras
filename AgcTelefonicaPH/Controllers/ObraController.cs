using AgcTelefonicaPH.Models;
using AgcTelefonicaPH.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AgcTelefonicaPH.Controllers
{
    public class ObraController : Controller
    {
        private readonly IObraRepositorio _obraRepositorio;

        public ObraController(IObraRepositorio obraRepositorio)
        {
            _obraRepositorio = obraRepositorio;
        }
        public IActionResult Index()
        {
            List<ObraModel> obra= _obraRepositorio.BuscarAll();
            return View(obra);
        }
        public IActionResult CriarObra()
        {
            return View();
        }
        public IActionResult EditarObra()
        {
            return View();
        }
        public IActionResult ApagarConfirmObra()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CriarObra(ObraModel obra)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _obraRepositorio.Adicionar(obra);
                    TempData["MensagemSucesso"] = "Obra criada com sucesso";
                    return RedirectToAction("Index");
                }

                return View(obra);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao criar a obra, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult CriarObra(int itemSelecionado)
        {
            return View();
        }
    }
}
