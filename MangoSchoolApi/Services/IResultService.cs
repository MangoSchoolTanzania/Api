using MangoSchoolApi.Models;

namespace MangoSchoolApi.Services
{
    public interface IResultService
    {
        public Task<Result> CalculateResultIndicators(Result result);
    }
}
