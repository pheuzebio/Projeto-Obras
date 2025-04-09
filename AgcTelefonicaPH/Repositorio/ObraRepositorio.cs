using AgcTelefonicaPH.Data;
using AgcTelefonicaPH.Models;

namespace AgcTelefonicaPH.Repositorio
{
    public class ObraRepositorio : IObraRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ObraRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ObraModel ListarPorId(int id)
        {
            return _bancoContext.Obras.FirstOrDefault(x => x.id == id);
        }
        public List<ObraModel> BuscarAll()
        {

            return _bancoContext.Obras.ToList();
        }
        public ObraModel Adicionar(ObraModel obra)
        {
            _bancoContext.Obras.Add(obra);
            _bancoContext.SaveChanges();
            return obra;
        }
    }
}
