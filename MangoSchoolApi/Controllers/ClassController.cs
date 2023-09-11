using MangoSchoolApi.Data;
using MangoSchoolApi.Models;
using MangoSchoolApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangoSchoolApi.Controllers
{
    [ApiController]
    [Route("v1/Class/")]
    public class ClassController : ControllerBase
    {
        private readonly MangoDataContext _MangoDataContext;
        public ClassController(MangoDataContext MangoDataContext)
        {
            _MangoDataContext = MangoDataContext;
        }

        [AllowAnonymous]
        [HttpGet("Paginated/{page}")]
        public async Task<IActionResult> GetClasses(int page)
        {
            try
            {
                var classes = await _MangoDataContext.Classes
                    .Where(x => x.IsActive == true)
                    .Skip(page * 10)
                    .Take(10)
                    .ToListAsync();

                return Ok(classes);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClass(int id)
        {
            try
            {
                var clasS = await _MangoDataContext.Classes
                    .Where(x => x.IsActive == true)
                    .FirstOrDefaultAsync(c => c.Id == id);
                
                if(clasS == null) return NotFound();
                
                return Ok(clasS);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostClass([FromBody]ClassViewModel ClassViewModel)
        {
            try
            {
                if (ClassViewModel == null) return NotFound();

                var ModelClass = new Class()
                {
                    Arith = ClassViewModel.Arith,
                    HE = ClassViewModel.HE,
                    Ave = ClassViewModel.Ave,
                    Kus = ClassViewModel.Kus,
                    Month = ClassViewModel.Month,
                    Name = ClassViewModel.Name,
                    Pos = ClassViewModel.Pos,
                    Read = ClassViewModel.Read,
                    SA = ClassViewModel.SA,
                    Total = ClassViewModel.Total,
                    Writ = ClassViewModel.Writ,
                    Year = ClassViewModel.Year,
                    IsActive = true
                };

                _MangoDataContext.Classes.Add(ModelClass);
                _MangoDataContext.SaveChanges();

                return Ok(ModelClass);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> PutClass([FromBody] ClassViewModel ClassViewModel)
        {
            try
            {
                var ClassFromDataBase = _MangoDataContext.Classes.FirstOrDefault(c => c.Id == ClassViewModel.Id);
                if (ClassFromDataBase == null) return NotFound();
                
                ClassFromDataBase.Arith = ClassViewModel.Arith;
                ClassFromDataBase.Writ = ClassViewModel.Writ;
                ClassFromDataBase.HE = ClassViewModel.HE;
                ClassFromDataBase.SA = ClassViewModel.SA;
                ClassFromDataBase.Ave = ClassViewModel.Ave;
                ClassFromDataBase.Kus = ClassViewModel.Kus;
                ClassFromDataBase.Month = ClassViewModel.Month;
                ClassFromDataBase.Read = ClassViewModel.Read;
                ClassFromDataBase.Total = ClassViewModel.Total;
                ClassFromDataBase.Name = ClassViewModel.Name;
                ClassFromDataBase.Pos = ClassViewModel.Pos;
                ClassFromDataBase.Year = ClassViewModel.Year;

                _MangoDataContext.Update(ClassFromDataBase);
                _MangoDataContext.SaveChanges();

                return Ok(ClassFromDataBase);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            try
            {
                var ClassFromDatabase = _MangoDataContext.Classes.FirstOrDefault(x => x.Id == id);
                if (ClassFromDatabase == null) { return NotFound(); }

                ClassFromDatabase.IsActive = false;

                _MangoDataContext.Update(ClassFromDatabase);
                _MangoDataContext.SaveChanges();

                return Ok(ClassFromDatabase);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
