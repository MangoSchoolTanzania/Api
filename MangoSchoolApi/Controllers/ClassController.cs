using MangoSchoolApi.Data;
using MangoSchoolApi.Models;
using MangoSchoolApi.ViewModel;
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

        [Authorize, HttpGet("Pag/{page}")]
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

        [Authorize, HttpPost]
        public async Task<IActionResult> PostClass([FromBody] ClassViewModel ClassViewModel)
        {
            try
            {
                var clasS = new Class()
                {
                    IsActive = true,
                    Month = ClassViewModel.Month,
                    Name = ClassViewModel.Name,
                    Year = ClassViewModel.Year,
                };

                _MangoDataContext.Classes.Add(clasS);
                _MangoDataContext.SaveChanges();

                return Ok(clasS);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
