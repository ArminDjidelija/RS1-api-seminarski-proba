using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Endpoints.Potkategorija.Pretraga;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Proizvod.Pretraga
{
    [Microsoft.AspNetCore.Mvc.Route("proizvod-pretraga")]
    public class ProizvodPretragaEndpoint : MyBaseEndpoint<ProizvodPretragaRequest, ProizvodPretragaResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProizvodPretragaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public override async Task<ActionResult<ProizvodPretragaResponse>> Obradi([FromQuery]ProizvodPretragaRequest request, CancellationToken cancellationToken = default)
        {
            var data = await _applicationDbContext
                .Proizvod
                .Where(x => request.Naziv == null || x.Naziv.ToLower().StartsWith(request.Naziv.ToLower()))
                .Select(x => new ProizvodPretragaResponse
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    BrendNaziv=x.Brend.Naziv,
                    PotkategorijaNaziv=x.Potkategorija.Naziv,
                    BrojKlikova=x.BrojKlikova,
                    Opis=x.Opis,
                    PocetnaKolicina=x.PocetnaKolicina,
                    PocetnaCijena=x.PocetnaCijena
                }).ToListAsync(cancellationToken: cancellationToken);

            return Ok(data);
        }
    }
}
