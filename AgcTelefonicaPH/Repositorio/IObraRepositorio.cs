using AgcTelefonicaPH.Models;

namespace AgcTelefonicaPH.Repositorio
{
    public interface IObraRepositorio
    {
        ObraModel Adicionar(ObraModel obra);
        List<ObraModel> BuscarAll();

    }
}
