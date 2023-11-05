namespace RS1_api_seminarski_proba.Endpoints.Kategorija.Update
{
    public class KategorijaUpdateRequest
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int GlavnaKategorijaID { get; set; }
    }
}
