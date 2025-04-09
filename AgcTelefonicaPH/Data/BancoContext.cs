using AgcTelefonicaPH.Models;
using Microsoft.EntityFrameworkCore;

namespace AgcTelefonicaPH.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext>options) : base(options)
        {
        }

        public DbSet<ContactoModel> Contactos { get; set; }

        public DbSet<ObraModel> Obras { get; set; }


    }
}
