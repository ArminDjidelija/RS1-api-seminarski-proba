using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_api_seminarski_proba.Endpoints.Proizvod.Update
{
    public class ProizvodUpdateRequest
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int PocetnaKolicina { get; set; } = 0;
        public float PocetnaCijena { get; set; }
        public string Opis { get; set; }
        
        public int BrendID { get; set; }    
        public int PotkategorijaID { get; set; }
        
    }
}
