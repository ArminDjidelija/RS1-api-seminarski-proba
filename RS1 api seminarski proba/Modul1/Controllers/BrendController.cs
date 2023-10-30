using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS1_api_seminarski_proba.Data;
using RS1_api_seminarski_proba.Modul1.Models;
using RS1_api_seminarski_proba.Modul1.ViewModels;

namespace RS1_api_seminarski_proba.Modul1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BrendController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public BrendController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll(string? filter)
        {
            var data = _dbContext.Brend
                .OrderBy(s => s.Id)
                .Where(s => filter == null || s.Naziv.ToLower().Contains(filter.ToLower()))
                .Select(s => new BrendGetRequest()
                {
                    id = s.Id,
                    naziv = s.Naziv
                });
            return Ok(data.ToList());
        }

        [HttpGet]
        public ActionResult GetBrandId(int id)
        {
            var obj = _dbContext.Brend.Find(id);

            if(obj==null)
            {
                return NotFound();
            }
            
            return Ok(obj);
        }

        [HttpPost]
        public Brend Post([FromBody] BrendInsertPost x)
        {
            Brend? obj;

            if (x.id == 0)
            {
                obj = new Brend();
                _dbContext.Add(obj);
            }
            else
            {
                obj = _dbContext.Brend.Find(x.id);
            }

            obj.Naziv = x.naziv;
            
            _dbContext.SaveChanges();
            return obj;
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var obj = _dbContext.Brend.Find(id);

            if (obj == null)
            {
                return BadRequest();
            }
            else
            {
                _dbContext.Brend.Remove(obj);
                _dbContext.SaveChanges();
            }
            return Ok(id);
        }
    }
}
