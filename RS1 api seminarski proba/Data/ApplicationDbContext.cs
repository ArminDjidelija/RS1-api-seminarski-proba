using Microsoft.EntityFrameworkCore;
using RS1_api_seminarski_proba.Modul1.Models;
using RS1_api_seminarski_proba.Modul1.Models.Kategorije;

namespace RS1_api_seminarski_proba.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Brend> Brend { get; set; }
        public DbSet<Kategorija> Kategorija{ get; set; }
        public DbSet<GlavnaKategorija> GlavnaKategorija{ get; set; }
        public DbSet<Potkategorija> Potkategorija { get; set; }
       

    }
}
