using MangoSchoolApi.Data;
using MangoSchoolApi.Models;
using MangoSchoolApi.ModelView;
using MangoSchoolApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangoSchoolApi.Controllers
{
    [ApiController]
    [Route("v1/Result/")]
    public class ResultController : ControllerBase
    {
        private readonly MangoDataContext _MangoDataContext;
        public ResultController(MangoDataContext MangoDataContext)
        {
            _MangoDataContext = MangoDataContext;
        }

        [AllowAnonymous]
        [HttpGet("Pag/{page}/filterParam/{filterSelectedPage}/stringParam/{stringParam}")]
        public async Task<IActionResult> GetResults(int page, string filterSelectedPage, string? stringParam)
        {
            try
            {
                if (filterSelectedPage == "All")
                {
                     var results = await _MangoDataContext.Results
                    .Include(x => x.Class)
                    .Where(x => x.IsActive == true)
                    .OrderBy(x => x.Class.Year)
                    .ThenBy(x => x.Class.Name)
                    .Skip(page * 15)
                    .Take(15)
                    .Select(x => new ResultModelView()
                    {
                        Id = x.Id,
                        ClassName = x.Class.Name,
                        ClassYear = x.Class.Year,
                        ClassMonth = x.Class.Month,
                        Name = x.Name,
                        Arith = x.Arith,
                        Ave = x.Ave,
                        HE = x.HE,
                        Kus = x.Kus,
                        IsActive = x.IsActive,
                        Pos = x.Pos,
                        Read = x.Read,
                        SA = x.SA,
                        Writ = x.Writ,
                        Total = x.Total,
                    })
                    .ToListAsync();

                    return Ok(results);
                }

                if(filterSelectedPage == "Class")
                {
                    var results = await _MangoDataContext.Results
                    .Include(x => x.Class)
                    .Where(x => x.IsActive == true && x.Class.Name.Contains(stringParam))
                    .OrderBy(x => x.Class.Year)
                    .ThenBy(x => x.Class.Name)
                    .Skip(page * 25)
                    .Take(25)
                    .Select(x => new ResultModelView()
                    {
                        Id = x.Id,
                        ClassName = x.Class.Name,
                        ClassYear = x.Class.Year,
                        Name = x.Name,
                        Arith = x.Arith,
                        Ave = x.Ave,
                        HE = x.HE,
                        Kus = x.Kus,
                        IsActive = x.IsActive,
                        Pos = x.Pos,
                        Read = x.Read,
                        SA = x.SA,
                        Writ = x.Writ,
                        Total = x.Total,
                    })
                    .ToListAsync();

                    return Ok(results);
                }

                if (filterSelectedPage == "Year")
                {
                    var results = await _MangoDataContext.Results
                    .Include(x => x.Class)
                    .Where(x => x.IsActive == true && x.Class.Year == int.Parse(stringParam))
                    .OrderBy(x => x.Class.Year)
                    .ThenBy(x => x.Class.Name)
                    .Skip(page * 25)
                    .Take(25)
                    .Select(x => new ResultModelView()
                    {
                        Id = x.Id,
                        ClassName = x.Class.Name,
                        ClassYear = x.Class.Year,
                        Name = x.Name,
                        Arith = x.Arith,
                        Ave = x.Ave,
                        HE = x.HE,
                        Kus = x.Kus,
                        IsActive = x.IsActive,
                        Pos = x.Pos,
                        Read = x.Read,
                        SA = x.SA,
                        Writ = x.Writ,
                        Total = x.Total,
                    })
                    .ToListAsync();

                    return Ok(results);
                }

                if (filterSelectedPage == "Student")
                {
                    var results = await _MangoDataContext.Results
                    .Include(x => x.Class)
                    .Where(x => x.IsActive == true && x.Name == stringParam)
                    .OrderBy(x => x.Class.Year)
                    .ThenBy(x => x.Class.Name)
                    .Skip(page * 25)
                    .Take(25)
                    .Select(x => new ResultModelView()
                    {
                        Id = x.Id,
                        ClassName = x.Class.Name,
                        ClassYear = x.Class.Year,
                        Name = x.Name,
                        Arith = x.Arith,
                        Ave = x.Ave,
                        HE = x.HE,
                        Kus = x.Kus,
                        IsActive = x.IsActive,
                        Pos = x.Pos,
                        Read = x.Read,
                        SA = x.SA,
                        Writ = x.Writ,
                        Total = x.Total,
                    })
                    .ToListAsync();

                    return Ok(results);
                }


                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize,HttpGet("ByClass/{classId}")]
        public async Task<IActionResult> GetResultsByClass(int classId)
        {
            try
            {
                var results = await _MangoDataContext.Results
                    .Where(x => x.ClassId == classId)
                    .Include(x => x.Class)
                    .OrderBy(x => x.Class.Year)
                    .ThenBy(x => x.Class.Name)
                    .Select(x => new ResultModelView()
                    {
                        Id = x.Id,
                        ClassName = x.Class.Name,
                        ClassYear = x.Class.Year,
                        ClassMonth = x.Class.Month,
                        Name = x.Name,
                        Arith = x.Arith,
                        Ave = x.Ave,
                        HE = x.HE,
                        Kus = x.Kus,
                        IsActive = x.IsActive,
                        Pos = x.Pos,
                        Read = x.Read,
                        SA = x.SA,
                        Writ = x.Writ,
                        Total = x.Total,
                    })
                    .ToListAsync();

                if (results.Count == 0) return NotFound();

                return Ok(results);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResult(int id)
        {
            try
            {
                var clasS = await _MangoDataContext.Results
                    .Where(x => x.IsActive == true)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (clasS == null) return NotFound();

                return Ok(clasS);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostResult([FromBody] ResultViewModel ResultViewModel)
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
        public async Task<IActionResult> PutResult([FromBody] ResultViewModel ResultViewModel)
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
        public async Task<IActionResult> DeleteResult(int id)
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
