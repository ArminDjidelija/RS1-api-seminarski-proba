namespace RS1_api_seminarski_proba.Modul1.ViewModels
{
    public class ProizvodGetRequest
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public int kolicina { get; set; }
        public float pocetnaCijena { get; set; }
        public int brojKlikova { get; set; }
        public string Opis { get; set; }
        public int brendID { get; set; }
        public int potkategorijaID { get; set; }
    }
}
