using MangoSchoolApi.Data;
using MangoSchoolApi.Models;
using MangoSchoolApi.Repository;
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
        public readonly IClassRepository _IClassRepository;
        public ClassController(IClassRepository IClassRepository)
        {
            _IClassRepository = IClassRepository;
        }

        [Authorize, HttpGet("Pag/{page}")]
        public async Task<IActionResult> GetClasses(int page)
        {
            try
            {
                var classes = await _IClassRepository.GetClasses(page);

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
                var clasS = await _IClassRepository.GetClass(id);

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
                    CreateDate = DateTime.Now
                };

                var clasSaved = _IClassRepository.PostClass(clasS);

                return Ok(clasSaved);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize, HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            try
            {
                var clasS = await _IClassRepository.DeleteClass(id);
                if (clasS == null) return NotFound();

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize,HttpPut()]
        public async Task<IActionResult> PutClass([FromBody]ClassViewModel ClassViewModel)
        {
            try
            {
                var clasS = await _IClassRepository.PutClass(ClassViewModel);

                return Ok(clasS);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
