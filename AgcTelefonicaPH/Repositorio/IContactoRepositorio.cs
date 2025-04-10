using AgcTelefonicaPH.Models;

namespace AgcTelefonicaPH.Repositorio
{
    public interface IContactoRepositorio
    {
        ContactoModel ListarPorId(int id);
        List<ContactoModel> BuscarAll();
        ContactoModel Adicionar(ContactoModel contacto, IFormFile imagem);
        ContactoModel Atualizar(ContactoModel contacto, IFormFile imagem);
        bool Apagar(int id);
    }
}
