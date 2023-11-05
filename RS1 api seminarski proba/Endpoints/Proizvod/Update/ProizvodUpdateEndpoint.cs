using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Endpoints.Potkategorija.Update;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Proizvod.Update
{
    [Microsoft.AspNetCore.Mvc.Route("proizvod-update")]
    public class ProizvodUpdateEndpoint:MyBaseEndpoint<ProizvodUpdateRequest, ProizvodUpdateResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProizvodUpdateEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<ActionResult<ProizvodUpdateResponse>> Obradi(ProizvodUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var proizvod = await _applicationDbContext.Proizvod.FindAsync(request.Id);

            if (proizvod == null)
            {
                return NotFound($"Nema proizvod sa Id = {request.Id} u bazi.");
            }

            proizvod.Naziv = request.Naziv;
            proizvod.BrendID=request.BrendID;
            proizvod.PocetnaCijena=request.PocetnaCijena;
            proizvod.PotkategorijaID=request.PotkategorijaID;
            proizvod.Opis = request.Opis;
            proizvod.PocetnaKolicina = request.PocetnaKolicina;

            await _applicationDbContext.SaveChangesAsync();

            return Ok(new ProizvodUpdateResponse()
            {
               Id= proizvod.Id,
               BrendNaziv=proizvod.Brend.Naziv,
               Naziv=proizvod.Naziv,
               Opis=proizvod.Opis, 
               PocetnaCijena=proizvod.PocetnaCijena,
               PocetnaKolicina=proizvod.PocetnaKolicina,
               PotkategorijaNaziv=proizvod.Potkategorija.Naziv
            });
        }
    }
}
