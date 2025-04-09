using System.Diagnostics.Contracts;
using AgcTelefonicaPH.Data;
using AgcTelefonicaPH.Models;

namespace AgcTelefonicaPH.Repositorio
{
    public class ContactoRepositorio : IContactoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContactoRepositorio(BancoContext bancoContext) 
        { 
            _bancoContext = bancoContext;
        }
        public ContactoModel ListarPorId(int id)
        {
            return _bancoContext.Contactos.FirstOrDefault(x => x.id == id);
        }
        public List<ContactoModel> BuscarAll()
        {
            return _bancoContext.Contactos.ToList();
        }
        public ContactoModel Adicionar(ContactoModel contacto)
        {
            _bancoContext.Contactos.Add(contacto);
            _bancoContext.SaveChanges();   
            return contacto;
        }

        public ContactoModel Atualizar(ContactoModel contacto)
        {
            ContactoModel contactoDB = ListarPorId(contacto.id);

            if (contactoDB == null) throw new System.Exception("Ocorreu um erro ao atualizar o contato");

            contactoDB.Cliente = contacto.Cliente;
            contactoDB.ContactoN = contacto.ContactoN;
            contactoDB.Cidade = contacto.Cidade;

            _bancoContext.Contactos.Update(contactoDB);
            _bancoContext.SaveChanges();

            return contactoDB;

        }

        public bool Apagar(int id)
        {
            ContactoModel contactoDB = ListarPorId(id);

            if (contactoDB == null) throw new System.Exception("Ocorreu um erro ao apagar o contato");

            _bancoContext.Contactos.Remove(contactoDB);
            _bancoContext.SaveChanges();
            
            return true;
        }
    }
}
