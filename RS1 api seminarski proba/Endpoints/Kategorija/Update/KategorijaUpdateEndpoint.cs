using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Endpoints.Glavna_kategorija.Update;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Kategorija.Update
{
    [Microsoft.AspNetCore.Mvc.Route("kategorija-update")]
    public class KategorijaUpdateEndpoint : MyBaseEndpoint<KategorijaUpdateRequest, KategorijaUpdateResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public KategorijaUpdateEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<ActionResult<KategorijaUpdateResponse>> Obradi(KategorijaUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var kategorija = await _applicationDbContext.Kategorija.FindAsync(request.Id);

            if (kategorija == null)
            {
                return NotFound($"Nema kategorije sa Id = {request.Id} u bazi.");
            }

            kategorija.Naziv = request.Naziv;
            kategorija.GlavnaKategorijaID = request.GlavnaKategorijaID;

            await _applicationDbContext.SaveChangesAsync();

            return Ok(new KategorijaUpdateResponse()
            {
                Id = request.Id,
                Naziv = request.Naziv
            });
        }
    }
}
