using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Brend.Update
{
    [Microsoft.AspNetCore.Mvc.Route("brend-update")]
    public class BrendUpdateEndpoint : MyBaseEndpoint<BrendUpdateRequest, BrendUpdateResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public BrendUpdateEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<ActionResult<BrendUpdateResponse>> Obradi([FromBody]BrendUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var brend = await _applicationDbContext.Brend.FindAsync(request.Id);

            if (brend == null)
            {
                return NotFound($"Nema brend sa Id = {request.Id} u bazi.");
            }

            brend.Naziv = request.Naziv;

            await _applicationDbContext.SaveChangesAsync();

            return Ok(new BrendUpdateResponse()
            {
                Id = request.Id,
                Naziv = request.Naziv,
            });

        }
    }
}
