using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RS1_api_seminarski_proba.Modul1.Models.Kategorije;

namespace RS1_api_seminarski_proba.Modul1.Models
{
    public class Proizvod
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int PocetnaKolicina { get; set; } = 0;
        public float PocetnaCijena { get; set; }
        public string Opis { get; set; }
        public int BrojKlikova { get; set; } = 0;

        public int BrendID { get; set; }
        [ForeignKey(nameof(BrendID))]
        public Brend Brend { get; set; }

        public int PotkategorijaID { get; set; }
        [ForeignKey(nameof(PotkategorijaID))]
        public Potkategorija Potkategorija { get; set; }

    }
}
