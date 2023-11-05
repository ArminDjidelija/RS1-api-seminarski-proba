namespace RS1_api_seminarski_proba.Endpoints.Proizvod.Dodaj
{
    public class ProizvodDodajResponse
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int PocetnaKolicina { get; set; }
        public float PocetnaCijena { get; set; }
        public int BrojKlikova { get; set; } 
        public string Opis { get; set; }
        public string NazivBrenda{ get; set; }
        public string NazivPotkategorije{ get; set; }
    }
}
