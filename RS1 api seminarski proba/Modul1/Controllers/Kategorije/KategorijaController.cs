using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Modul1.Models.Kategorije;
using RS1_api_seminarski_proba.Modul1.ViewModels;

namespace RS1_api_seminarski_proba.Modul1.Controllers.Kategorije
{
    //[ApiController]
    //[Route("[controller]/[action]")]
    public class KategorijaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public KategorijaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll(string? filter)
        {
            var data = _dbContext.Kategorija
                .OrderBy(s => s.Id)
                .Where(s => filter == null || s.Naziv.ToLower().Contains(filter.ToLower()))
                .Select(s => new KategorijaGetRequest()
                {
                    id = s.Id,
                    naziv = s.Naziv,
                    glavnaKategorijaID=s.GlavnaKategorijaID
                });
            return Ok(data.ToList());
        }

        [HttpGet]
        public ActionResult GetKategorijaId(int id)
        {
            var obj = _dbContext.Kategorija.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpPost]
        public Kategorija Post([FromBody] KategorijaInsertPost x)
        {
            Kategorija? obj;

            if (x.id == 0)
            {
                obj = new Kategorija();
                _dbContext.Add(obj);
            }
            else
            {
                obj = _dbContext.Kategorija.Find(x.id);
            }

            obj.Naziv = x.naziv;
            obj.GlavnaKategorijaID = x.glavnaKategorijaID;

            _dbContext.SaveChanges();
            return obj;
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var obj = _dbContext.Kategorija.Find(id);

            if (obj == null)
            {
                return BadRequest();
            }
            else
            {
                _dbContext.Kategorija.Remove(obj);
                _dbContext.SaveChanges();
            }
            return Ok(id);
        }
    }
}
