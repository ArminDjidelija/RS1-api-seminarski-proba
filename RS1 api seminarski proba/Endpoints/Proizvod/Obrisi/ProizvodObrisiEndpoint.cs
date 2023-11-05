using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Endpoints.Potkategorija.Obrisi;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Proizvod.Obrisi
{
    [Microsoft.AspNetCore.Mvc.Route("proizvod-obrisi")]
    public class ProizvodObrisiEndpoint : MyBaseEndpoint<ProizvodObrisiRequest, ProizvodObrisiResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProizvodObrisiEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpDelete]
        public override async Task<ActionResult<ProizvodObrisiResponse>> Obradi([FromQuery]ProizvodObrisiRequest request, CancellationToken cancellationToken = default)
        {
            var pronadjen = await _applicationDbContext.Proizvod.FindAsync(request.Id);
            if (pronadjen == null)
            {
                return NotFound("Nema objekta u bazi");
            }

            _applicationDbContext.Proizvod.Remove(pronadjen);

            await _applicationDbContext.SaveChangesAsync();

            return Ok(new ProizvodObrisiResponse()
            {
                
            });
        }
    }
}
