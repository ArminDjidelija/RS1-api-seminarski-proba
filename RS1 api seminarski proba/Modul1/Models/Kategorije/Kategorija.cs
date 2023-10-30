using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_api_seminarski_proba.Modul1.Models.Kategorije
{
    public class Kategorija
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }

        public int GlavnaKategorijaID { get; set; }
        [ForeignKey(nameof(GlavnaKategorijaID))]
        public GlavnaKategorija GlavnaKategorija { get; set; }

    }
}
