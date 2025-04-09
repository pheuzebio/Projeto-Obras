using AgcTelefonicaPH.Models;

namespace AgcTelefonicaPH.Repositorio
{
    public interface IContactoRepositorio
    {
        ContactoModel ListarPorId(int id);
        List<ContactoModel> BuscarAll();
        ContactoModel Adicionar(ContactoModel contacto);
        ContactoModel Atualizar(ContactoModel contacto);
        bool Apagar(int id);
    }
}
