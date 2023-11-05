using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Proizvod.Dodaj
{
    [Microsoft.AspNetCore.Mvc.Route("proizvod-dodaj")]
    public class ProizvodDodajEndpoint : MyBaseEndpoint<ProizvodDodajRequest, ProizvodDodajRequest>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProizvodDodajEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<ActionResult<ProizvodDodajRequest>> Obradi([FromBody]ProizvodDodajRequest request, CancellationToken cancellationToken = default)
        {
            var pronadjen = await FindProizvodByName(_applicationDbContext, request.Naziv);
            if (request == null || request.Naziv == "" || pronadjen != null)
            {
                return BadRequest("Postoji takav proizvod u bazi ili nije unesen naziv proizvoda.");
            }
            var obj = new Modul1.Models.Proizvod()
            {
                Naziv=request.Naziv,
                Opis = request.Opis,
                PocetnaCijena=request.PocetnaCijena,
                PocetnaKolicina=request.PocetnaKolicina,
                BrendID=request.BrendID,
                PotkategorijaID=request.PotkategorijaID,              
            };

            await _applicationDbContext.AddAsync(obj, cancellationToken);

            await _applicationDbContext.SaveChangesAsync();

            return Ok(new ProizvodDodajResponse()
            {
                Id = obj.Id,
                Naziv = obj.Naziv,
                BrojKlikova=obj.BrojKlikova,
                NazivBrenda=obj.Brend.Naziv,
                NazivPotkategorije=obj.Potkategorija.Naziv,
                Opis=obj.Opis,
                PocetnaCijena=obj.PocetnaCijena,
                PocetnaKolicina=obj.PocetnaKolicina
            });
        }

        public static async Task<Modul1.Models.Proizvod> FindProizvodByName(ApplicationDbContext context, string naziv)
        {
            return await Task.Run(() => context.Proizvod.FirstOrDefaultAsync(x => x.Naziv == naziv));
        }
    }
}
