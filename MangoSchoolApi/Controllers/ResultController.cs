using MangoSchoolApi.Models;
using MangoSchoolApi.Models.Models;
using MangoSchoolApi.Models.ViewModel;
using MangoSchoolApi.Repository;
using MangoSchoolApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MangoSchoolApi.Controllers
{
    [ApiController]
    [Route("v1/Result/")]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepository _ResultRepository;
        private readonly IResultService _ResultService;
        public ResultController(IResultRepository ResultRepository, IResultService ResultService)
        {
            _ResultRepository = ResultRepository;
            _ResultService = ResultService;
        }

        [AllowAnonymous]
        [HttpGet("Pag/{page}/filterParam/{filterSelectedPage}/stringParam/{stringParam}")]
        public async Task<IActionResult> GetResults(int page, string filterSelectedPage, string? stringParam)
        {
            try
            {
                var results = await _ResultRepository.GetResults(page, filterSelectedPage, stringParam);
                
                if(results.Any()) return Ok(results);
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
                var results = await _ResultRepository.GetResultsByClass(classId);
                
                if (results.Any()) return Ok(results);
                return NotFound();
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
                var clasS = await _ResultRepository.GetResult(id);

                if (clasS != null) return Ok(clasS);
                return NotFound();
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
                    CreateDate = DateTime.Now,
                    Arith = ResultViewModel.Arith,
                    HE = ResultViewModel.HE,
                    Kus = ResultViewModel.Kus,
                    Name = ResultViewModel.Name,
                    Pos = ResultViewModel.Pos,
                    Read = ResultViewModel.Read,
                    SA = ResultViewModel.SA,
                    Writ = ResultViewModel.Writ,
                    IsActive = true,
                    ClassId = ResultViewModel.ClassId,
                };

                ModelClass = await _ResultService.CalculateResultIndicators(ModelClass);
                var result = await _ResultRepository.PostResult(ModelClass);

                if (result == true)
                {
                    return Ok(ModelClass);
                }

                return NotFound();
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
                var result = await _ResultRepository.PutResult(ResultViewModel);
                return Ok(result);
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
                var resultFromDatabase = _ResultRepository.DeleteResult(id);
                return Ok(resultFromDatabase);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
