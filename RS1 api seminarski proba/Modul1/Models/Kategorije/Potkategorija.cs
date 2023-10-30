using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_api_seminarski_proba.Modul1.Models.Kategorije
{
    public class Potkategorija
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }

        public int KategorijaID { get; set; }
        [ForeignKey(nameof(KategorijaID))]
        public Kategorija Kategorija { get; set; }
    }
}
