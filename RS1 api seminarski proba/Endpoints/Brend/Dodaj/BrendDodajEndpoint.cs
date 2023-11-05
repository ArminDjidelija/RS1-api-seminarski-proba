using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Helpers;

namespace RS1_api_seminarski_proba.Endpoints.Brend.Dodaj
{
    [Microsoft.AspNetCore.Mvc.Route("brend-dodaj")]
    public class BrendDodajEndpoint : MyBaseEndpoint<BrendDodajRequest, BrendDodajResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BrendDodajEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<ActionResult<BrendDodajResponse>> Obradi([FromBody]BrendDodajRequest request, CancellationToken cancellationToken=default)
        {
            var noviObj = new Modul1.Models.Brend
            {
                Naziv = request.Naziv
            };

            _applicationDbContext.Brend.Add(noviObj);

            await _applicationDbContext.SaveChangesAsync();

            return Ok(new BrendDodajResponse
            {
                Id = noviObj.Id
            });

        }
    }
}
