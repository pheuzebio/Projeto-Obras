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

        public ObraModel Atualizar(ObraModel obra)
        {
            ObraModel obraDB = ListarPorId(obra.id);

            if (obraDB == null) throw new System.Exception("Ocorreu um erro ao atualizar a obra");

            obraDB.id = obra.id;
            obraDB.Descricao = obra.Descricao;
            obraDB.DatIni = obra.DatIni;
            obraDB.DatFim = obra.DatFim;
            obraDB.idCliente = obra.idCliente;

            _bancoContext.Obras.Update(obraDB);
            _bancoContext.SaveChanges();

            return obraDB;

        }

        public bool Apagar(int id)
        {
            ObraModel obraDB = ListarPorId(id);
            if (obraDB == null) throw new System.Exception("Ocorreu um erro ao apagar o contato");

            _bancoContext.Obras.Remove(obraDB);
            _bancoContext.SaveChanges();

            return true;
        }
        public ContactoModel ListarPorIdCliente(int id)
        {
            return _bancoContext.Contactos.FirstOrDefault(x => x.id == id);
        }


    }
}
