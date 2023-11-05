using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Kategorija.Pretraga
{
    [Microsoft.AspNetCore.Mvc.Route("kategorija-pretraga")]
    public class KategorijaPretragaEndpoint : MyBaseEndpoint<KategorijaPretragaRequest, KategorijaPretragaResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public KategorijaPretragaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public override async Task<ActionResult<KategorijaPretragaResponse>> Obradi([FromQuery]KategorijaPretragaRequest request, CancellationToken cancellationToken = default)
        {
            var data = await _applicationDbContext
                .Kategorija
                .Where(x => request.Naziv == null || x.Naziv.ToLower().StartsWith(request.Naziv.ToLower()))
                .Select(x => new KategorijaPretragaResponse
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    GlavnaKategorijaNaziv = x.GlavnaKategorija.Naziv
                }).ToListAsync(cancellationToken: cancellationToken);

            return Ok(data);
        }
    }
}
