using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Endpoints.Glavna_kategorija.Obrisi;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Kategorija.Obrisi
{
    [Microsoft.AspNetCore.Mvc.Route("kategorija-obrisi")]
    public class KategorijaObrisiEndpoint : MyBaseEndpoint<KategorijaObrisiRequest, KategorijaObrisiResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public KategorijaObrisiEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpDelete]
        public override async Task<ActionResult<KategorijaObrisiResponse>> Obradi([FromQuery]KategorijaObrisiRequest request, CancellationToken cancellationToken = default)
        {
            var pronadjen = await _applicationDbContext.Kategorija.FindAsync(request.Id);
            if (pronadjen == null)
            {
                return NotFound("Nema objekta u bazi");
            }

            _applicationDbContext.Kategorija.Remove(pronadjen);

            await _applicationDbContext.SaveChangesAsync();

            return Ok(new KategorijaObrisiResponse()
            {

            });
        }
    }
}
