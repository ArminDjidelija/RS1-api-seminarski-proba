using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_api_seminarski_proba.Endpoints.Proizvod.Pretraga
{
    public class ProizvodPretragaResponse
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int PocetnaKolicina { get; set; }
        public float PocetnaCijena { get; set; }
        public string Opis { get; set; }
        public int BrojKlikova { get; set; }

        public string BrendNaziv { get; set; }

        public string PotkategorijaNaziv { get; set; }
    }
}
