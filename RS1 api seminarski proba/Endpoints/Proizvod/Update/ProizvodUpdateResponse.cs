namespace RS1_api_seminarski_proba.Endpoints.Proizvod.Update
{
    public class ProizvodUpdateResponse
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int PocetnaKolicina { get; set; } = 0;
        public float PocetnaCijena { get; set; }
        public string Opis { get; set; }

        public string BrendNaziv{ get; set; }
        public string PotkategorijaNaziv { get; set; }
    }
}
