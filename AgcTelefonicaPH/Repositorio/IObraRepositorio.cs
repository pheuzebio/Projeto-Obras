using AgcTelefonicaPH.Models;

namespace AgcTelefonicaPH.Repositorio
{
    public interface IObraRepositorio
    {
        ObraModel Adicionar(ObraModel obra);
        List<ObraModel> BuscarAll();
        ObraModel ListarPorId(int id);
        ContactoModel ListarPorIdCliente(int id);
        ObraModel Atualizar (ObraModel obra);
        bool Apagar(int id);
    }
}
