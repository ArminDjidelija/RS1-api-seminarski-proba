using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Modul1.Models.Kategorije;
using RS1_api_seminarski_proba.Modul1.ViewModels;

namespace RS1_api_seminarski_proba.Modul1.Controllers.Kategorije
{
    //[ApiController]
    //[Route("[controller]/[action]")]
    public class GlavnaKategorijaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GlavnaKategorijaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll(string? filter)
        {
            var data = _dbContext.GlavnaKategorija
                .OrderBy(s => s.Id)
                .Where(s => filter == null || s.Naziv.ToLower().Contains(filter.ToLower()))
                .Select(s => new GlavnaKategorijaGetRequest()
                {
                    id = s.Id,
                    naziv = s.Naziv
                });
            return Ok(data.ToList());
        }

        [HttpGet]
        public ActionResult GetGlavnaKategorijaId(int id)
        {
            var obj = _dbContext.GlavnaKategorija.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpPost]
        public GlavnaKategorija Post([FromBody] GlavnaKategorijaInsertPost x)
        {
            GlavnaKategorija? obj;

            if (x.id == 0)
            {
                obj = new GlavnaKategorija();
                _dbContext.Add(obj);
            }
            else
            {
                obj = _dbContext.GlavnaKategorija.Find(x.id);
            }

            obj.Naziv = x.naziv;

            _dbContext.SaveChanges();
            return obj;
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var obj = _dbContext.GlavnaKategorija.Find(id);

            if (obj == null)
            {
                return BadRequest();
            }
            else
            {
                _dbContext.GlavnaKategorija.Remove(obj);
                _dbContext.SaveChanges();
            }
            return Ok(id);
        }
    }
}
