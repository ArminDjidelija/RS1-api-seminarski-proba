using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Endpoints.Brend.Dodaj;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Brend.Obrisi
{
    [Microsoft.AspNetCore.Mvc.Route("brend-obrisi")]
    public class BrendObrisiEndpoint : MyBaseEndpoint<BrendObrisiRequest, BrendObrisiResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BrendObrisiEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpDelete]
        public override async Task<ActionResult<BrendObrisiResponse>> Obradi([FromQuery] BrendObrisiRequest request, CancellationToken cancellationToken = default)
        {
            var obj = await _applicationDbContext.Brend.FindAsync(request.BrendID);
            if (obj == null)
            {
                return NotFound($"Brend sa Id = {request.BrendID} ne postoji u bazi.");
            }

            _applicationDbContext.Remove(obj);
            await _applicationDbContext.SaveChangesAsync();

            return Ok(new BrendObrisiResponse
            {

            });

        }
    }
}
