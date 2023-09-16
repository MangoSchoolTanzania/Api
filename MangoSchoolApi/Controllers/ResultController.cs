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
    public class ResultController : ControllerBase
    {
        private readonly MangoDataContext _MangoDataContext;
        public ResultController(MangoDataContext MangoDataContext)
        {
            _MangoDataContext = MangoDataContext;
        }

        [AllowAnonymous]
        [HttpGet("Paginated/{page}")]
        public async Task<IActionResult> GetClasses(int page)
        {
            try
            {
                var classes = await _MangoDataContext.Results
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
                var clasS = await _MangoDataContext.Results
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
        public async Task<IActionResult> PostClass([FromBody]ResultViewModel ResultViewModel)
        {
            try
            {
                if (ResultViewModel == null) return NotFound();

                var ModelClass = new Result()
                {
                    Arith = ResultViewModel.Arith,
                    HE = ResultViewModel.HE,
                    Ave = ResultViewModel.Ave,
                    Kus = ResultViewModel.Kus,
                    Name = ResultViewModel.Name,
                    Pos = ResultViewModel.Pos,
                    Read = ResultViewModel.Read,
                    SA = ResultViewModel.SA,
                    Total = ResultViewModel.Total,
                    Writ = ResultViewModel.Writ,
                    IsActive = true
                };

                _MangoDataContext.Results.Add(ModelClass);
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
        public async Task<IActionResult> PutClass([FromBody] ResultViewModel ResultViewModel)
        {
            try
            {
                var ClassFromDataBase = _MangoDataContext.Results.FirstOrDefault(c => c.Id == ResultViewModel.Id);
                if (ClassFromDataBase == null) return NotFound();
                
                ClassFromDataBase.Arith = ResultViewModel.Arith;
                ClassFromDataBase.Writ = ResultViewModel.Writ;
                ClassFromDataBase.HE = ResultViewModel.HE;
                ClassFromDataBase.SA = ResultViewModel.SA;
                ClassFromDataBase.Ave = ResultViewModel.Ave;
                ClassFromDataBase.Kus = ResultViewModel.Kus;
                ClassFromDataBase.Read = ResultViewModel.Read;
                ClassFromDataBase.Total = ResultViewModel.Total;
                ClassFromDataBase.Name = ResultViewModel.Name;
                ClassFromDataBase.Pos = ResultViewModel.Pos;

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
                var ClassFromDatabase = _MangoDataContext.Results.FirstOrDefault(x => x.Id == id);
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
