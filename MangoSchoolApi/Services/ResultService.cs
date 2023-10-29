using MangoSchoolApi.Models;

namespace MangoSchoolApi.Services
{
    public class ResultService : IResultService
    {
        public async Task<Result> CalculateResultIndicators(Result result)
        {
            var totalCalculation = result.Arith + result.Kus + result.HE + result.SA + result.Writ + result.Read;
            var numberOfValues = 6; 
            result.Ave = totalCalculation / numberOfValues;
            result.Total = totalCalculation;
            result.Pos = 0; //Check with maurus what is pos
            return result;
        }
    }
}
