using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Endpoints.Kategorija.Pretraga;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Potkategorija.Pretraga
{
    [Microsoft.AspNetCore.Mvc.Route("potkategorija-pretraga")]
    public class PotkategorijaPretragaEndpoint : MyBaseEndpoint<PotkategorijaPretragaRequest, PotkategorijaPretragaResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PotkategorijaPretragaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public override async Task<ActionResult<PotkategorijaPretragaResponse>> Obradi([FromQuery]PotkategorijaPretragaRequest request, CancellationToken cancellationToken = default)
        {
            var data = await _applicationDbContext
                .Potkategorija
                .Where(x => request.Naziv == null || x.Naziv.ToLower().StartsWith(request.Naziv.ToLower()))
                .Select(x => new PotkategorijaPretragaResponse
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    KategorijaNaziv = x.Kategorija.Naziv
                }).ToListAsync(cancellationToken: cancellationToken);

            return Ok(data);
        }
    }
}
