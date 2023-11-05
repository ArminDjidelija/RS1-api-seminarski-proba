using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Endpoints.Glavna_kategorija.Dodaj;
using RS1_api_seminarski_proba.Helpers;
using RS1_api_seminarski_proba.Modul1.Models.Kategorije;

namespace RS1_api_seminarski_proba.Endpoints.Kategorija.Dodaj
{
    [Microsoft.AspNetCore.Mvc.Route("kategorija-dodaj")]
    public class KategorijaDodajEndpoint : MyBaseEndpoint<KategorijaDodajRequest, KategorijaDodajResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public KategorijaDodajEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<ActionResult<KategorijaDodajResponse>> Obradi([FromBody]KategorijaDodajRequest request, CancellationToken cancellationToken = default)
        {
            var pronadjen = await FindKategorijaByName(_applicationDbContext, request.Naziv);
            if (request == null || request.Naziv == "" || pronadjen != null)
            {
                return BadRequest("Postoji takva kategorija u bazi ili nije unesen tekst kategorije.");
            }
            var obj = new Modul1.Models.Kategorije.Kategorija()
            {
                Naziv=request.Naziv,
                GlavnaKategorijaID=request.GlavnaKategorijaID
            };

            await _applicationDbContext.AddAsync(obj, cancellationToken);

            await _applicationDbContext.SaveChangesAsync();

            return Ok(new KategorijaDodajResponse
            {
                Id = obj.Id,
                Naziv= obj.Naziv,
                GlavnaKategorijaNaziv=obj.GlavnaKategorija.Naziv
            });
        }

        public static async Task<Modul1.Models.Kategorije.Kategorija> FindKategorijaByName(ApplicationDbContext context, string naziv)
        {
            return await Task.Run(() => context.Kategorija.FirstOrDefaultAsync(x => x.Naziv == naziv));
        }
    }
}
