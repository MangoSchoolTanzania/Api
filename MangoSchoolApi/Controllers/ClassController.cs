using MangoSchoolApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace MangoSchoolApi.Controllers
{
    [ApiController]
    [Route("/v1/Class/")]
    public class ClassController : ControllerBase
    {
        public readonly MangoDataContext _MangoDataContext;
        public ClassController(MangoDataContext MangoDataContext)
        {
            _MangoDataContext = MangoDataContext;
        }

        [Authorize,HttpGet("GetMany/{page}")]
        public async Task<IActionResult> GetClasses(int page)
        {
            try
            {
                var classes = await _MangoDataContext.Classes
                    .Skip(10 * page)
                    .Take(10)
                    .Where(x => x.IsActive)
                    .ToListAsync();

                return Ok(classes);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize, HttpGet("{id}")]
        public async Task<IActionResult> GetClass(int id)
        {
            try
            {
                var clasS = await _MangoDataContext.Classes
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (clasS == null) return NotFound();

                return Ok(clasS);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
