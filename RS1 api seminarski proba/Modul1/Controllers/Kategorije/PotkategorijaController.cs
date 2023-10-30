using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Modul1.Models.Kategorije;
using RS1_api_seminarski_proba.Modul1.ViewModels;

namespace RS1_api_seminarski_proba.Modul1.Controllers.Kategorije
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PotkategorijaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public PotkategorijaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll(string? filter)
        {
            var data = _dbContext.Potkategorija
                .OrderBy(s => s.Id)
                .Where(s => filter == null || s.Naziv.ToLower().Contains(filter.ToLower()))
                .Select(s => new PotkategorijaGetRequest()
                {
                    id = s.Id,
                    naziv = s.Naziv,
                    kategorijaID = s.KategorijaID,
                });
            return Ok(data.ToList());
        }

        [HttpGet]
        public ActionResult GetBrandId(int id)
        {
            var obj = _dbContext.Potkategorija.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpPost]
        public Potkategorija Post([FromBody] PotkategorijaInsertPost x)
        {
            Potkategorija? obj;

            if (x.id == 0)
            {
                obj = new Potkategorija();
                _dbContext.Add(obj);
            }
            else
            {
                obj = _dbContext.Potkategorija.Find(x.id);
            }

            obj.Naziv = x.naziv;
            obj.KategorijaID=x.kategorijaID;

            _dbContext.SaveChanges();
            return obj;
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var obj = _dbContext.Potkategorija.Find(id);

            if (obj == null)
            {
                return BadRequest();
            }
            else
            {
                _dbContext.Potkategorija.Remove(obj);
                _dbContext.SaveChanges();
            }
            return Ok(id);
        }
    }
}
