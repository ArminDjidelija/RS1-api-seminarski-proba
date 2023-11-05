using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Endpoints.Brend.Update;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Glavna_kategorija.Update
{
    [Microsoft.AspNetCore.Mvc.Route("glavna-kategorija-update")]
    public class GlavnaKategorijaUpdateEndpoint : MyBaseEndpoint<GlavnaKategorijaUpdateRequest, GlavnaKategorijaUpdateResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GlavnaKategorijaUpdateEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<ActionResult<GlavnaKategorijaUpdateResponse>> Obradi([FromBody]GlavnaKategorijaUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var glavnaKategorija = await _applicationDbContext.GlavnaKategorija.FindAsync(request.Id);

            if (glavnaKategorija == null)
            {
                return NotFound($"Nema glavne kategorija sa Id = {request.Id} u bazi.");
            }

            glavnaKategorija.Naziv = request.Naziv;

            await _applicationDbContext.SaveChangesAsync();

            return Ok(new GlavnaKategorijaUpdateResponse()
            {
                Id = request.Id,
                Naziv=request.Naziv
            });
        }
    }
}
