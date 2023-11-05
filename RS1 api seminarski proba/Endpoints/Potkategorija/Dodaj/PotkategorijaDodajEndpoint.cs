using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Potkategorija.Dodaj
{
    [Microsoft.AspNetCore.Mvc.Route("potkategorija-dodaj")]
    public class PotkategorijaDodajEndpoint : MyBaseEndpoint<PotkategorijaDodajRequest, PotkategorijaDodajResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PotkategorijaDodajEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<ActionResult<PotkategorijaDodajResponse>> Obradi([FromBody]PotkategorijaDodajRequest request, CancellationToken cancellationToken = default)
        {
            var pronadjen = await FindKategorijaByName(_applicationDbContext, request.Naziv);
            if (request == null || request.Naziv == "" || pronadjen != null)
            {
                return BadRequest("Postoji takva potkategorija u bazi ili nije unesen tekst potkategorije.");
            }
            var obj = new Modul1.Models.Kategorije.Potkategorija()
            {
                Naziv = request.Naziv,
                KategorijaID = request.KategorijaID
            };

            await _applicationDbContext.AddAsync(obj, cancellationToken);

            await _applicationDbContext.SaveChangesAsync();

            return Ok(new Modul1.Models.Kategorije.Potkategorija()
            {
                Id = obj.Id,
                Naziv = obj.Naziv,
                KategorijaID = obj.KategorijaID
            });
        }

        public static async Task<Modul1.Models.Kategorije.Potkategorija> FindKategorijaByName(ApplicationDbContext context, string naziv)
        {
            return await Task.Run(() => context.Potkategorija.FirstOrDefaultAsync(x => x.Naziv == naziv));
        }
    }
}
