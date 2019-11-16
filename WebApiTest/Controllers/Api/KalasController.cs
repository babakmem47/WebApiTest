using System.Linq;
using System.Web.Http;
using WebApiTest.Dtos;
using WebApiTest.Models;

namespace WebApiTest.Controllers.Api
{
    public class KalasController : ApiController
    {
        private ApplicationDbContext _context;

        public KalasController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetAllKalas()
        {
            var kalas = _context.Kalas
                .ToList()
                .Where(k => !k.Deleted);

            return Ok(kalas.Select(x => new KalaDto()
            {
                Id = x.Id,
                Name = x.Name,
                Model = x.Model,
                Color = x.Color,
                Count = x.Count,
                Price = x.Price
            }));
        }

        public IHttpActionResult GetKalasNames()
        {
            var names = _context.Kalas
                .ToList()
                .Select(k => k.Name);

            return Ok(names);
        }

        public IHttpActionResult GetKalasIdAndName()
        {
            var kalasIdAndName = _context.Kalas
                .ToList()
                .Where(k => !k.Deleted);

            return Ok(kalasIdAndName.Select(k => new KalaDto2()
            {
                Id = k.Id,
                Name = k.Name
            }));
        }

        [HttpGet]
        //[Route("api/kalas/searchkalabyname/{kalaname}")]   // this also work
        public IHttpActionResult SearchKalaByname(string id)
        {
            var kala = _context.Kalas
                .SingleOrDefault(k => k.Name == id
                                      && !k.Deleted && k.Count > 0);

            if (kala != null)
                return Ok(new { data = kala });

            //else return a list of kalas that their names contain the keyword:
            var kalasThatNamesContainsKeyWord = _context.Kalas.ToList()
                .Where(k => k.Name.Contains(id)
                            && !k.Deleted);

            return Ok(kalasThatNamesContainsKeyWord);
        }
    }
}
