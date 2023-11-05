using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Endpoints.Glavna_kategorija.Dodaj;
using RS1_api_seminarski_proba.Helpers;
using RS1_api_seminarski_proba.Modul1.Models.Kategorije;

namespace RS1_api_seminarski_proba.Endpoints.Glavna_kategorija.Dodaj
{
    [Microsoft.AspNetCore.Mvc.Route("glavna-kategorija-dodaj")]
    public class GlavnaKategorijaDodajEndpoint : MyBaseEndpoint<GlavnaKategorijaDodajRequest, GlavnaKategorijaDodajResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GlavnaKategorijaDodajEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<ActionResult<GlavnaKategorijaDodajResponse>> Obradi([FromBody]GlavnaKategorijaDodajRequest request, CancellationToken cancellationToken = default)
        {
            var pronadjen= await FindGlavnaKategorijaByName(_applicationDbContext, request.Naziv);
            if(request==null||request.Naziv=="" || pronadjen != null)
            {
                return BadRequest("Postoji takva glavna kategorija u bazi ili nije unesen tekst kategorije.");
            }
            var obj = new GlavnaKategorija()
            {
                Naziv = request.Naziv,
            };
            await _applicationDbContext.AddAsync(obj, cancellationToken);

            await _applicationDbContext.SaveChangesAsync();
            return Ok(new GlavnaKategorijaDodajResponse()
            {
                Id = obj.Id
            });
        }

        public static async Task<GlavnaKategorija> FindGlavnaKategorijaByName(ApplicationDbContext context, string naziv)
        {
            return await Task.Run(() => context.GlavnaKategorija.FirstOrDefaultAsync(x => x.Naziv == naziv));
        }

    }
}
