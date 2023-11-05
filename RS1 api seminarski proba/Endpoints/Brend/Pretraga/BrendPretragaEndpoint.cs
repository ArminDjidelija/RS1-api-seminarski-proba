using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Endpoints.Brend.Dodaj;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Brend.Pretraga
{
    [Microsoft.AspNetCore.Mvc.Route("brend-pretraga")]
    public class BrendPretragaEndpoint : MyBaseEndpoint<BrendPretragaRequest, BrendPretragaResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BrendPretragaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public override async Task<ActionResult<BrendPretragaResponse>> Obradi([FromQuery] BrendPretragaRequest request, CancellationToken cancellationToken = default)
        {
            var obj = await _applicationDbContext
                .Brend
                .Where(x => request.Naziv == null || x.Naziv.ToLower().StartsWith(request.Naziv.ToLower()))
                .Select(x => new BrendPretragaResponse()
                {
                    Id = x.Id,
                    Naziv = x.Naziv
                }).ToListAsync(cancellationToken: cancellationToken);

            return Ok(obj);

        }
    }
}
