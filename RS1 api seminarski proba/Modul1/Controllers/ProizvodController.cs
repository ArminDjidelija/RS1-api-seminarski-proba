using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Modul1.Models;
using RS1_api_seminarski_proba.Modul1.ViewModels;

namespace RS1_api_seminarski_proba.Modul1.Views
{
    //[ApiController]
    //[Route("[controller]/[action]")]
    public class ProizvodController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ProizvodController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll(string? filter)
        {
            var data = _dbContext.Proizvod
                .OrderBy(s => s.Naziv)
                .Where(s => filter == null || s.Naziv.ToLower().Contains(filter.ToLower()))
                .Select(s => new ProizvodGetRequest()
                {
                    id = s.Id,
                    naziv = s.Naziv,
                    kolicina = s.PocetnaKolicina,
                    pocetnaCijena = s.PocetnaCijena,
                    Opis = s.Opis,
                    brojKlikova = s.BrojKlikova,
                    brendID = s.BrendID,
                    potkategorijaID = s.PotkategorijaID
                });
            return Ok(data.ToList());
        }

        [HttpPost]
        public Proizvod Post([FromBody] ProizvodInsertPost x)
        {
            Proizvod? obj;

            if(x.id==0)
            {
                obj=new Proizvod();
                _dbContext.Add(obj);
            }
            else
            {
                obj = _dbContext.Proizvod.Find(x.id);
            }

            obj.Naziv = x.naziv;
            obj.PocetnaKolicina = x.kolicina;
            obj.Opis=x.opis;
            obj.PocetnaCijena = x.pocetnaCijena;
            obj.PotkategorijaID = x.PotkategorijaID;
            obj.BrendID = x.BrendID;

            _dbContext.SaveChanges();
            return obj;
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var obj = _dbContext.Proizvod.Find(id);

            if(obj==null)
            {
                return BadRequest();
            }
            else
            {
                _dbContext.Proizvod.Remove(obj);
                _dbContext.SaveChanges();
            }
            return Ok(id);
        }
      


    }
}
