using MangoSchoolApi.Models.Models;
using MangoSchoolApi.Models.ModelView;
using MangoSchoolApi.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MangoSchoolApi.Repository
{
    public interface IResultRepository
    {
        public Task<List<ResultModelView>> GetResults(int page, string filterSelectedPage, string? stringParam);
        public Task<List<ResultModelView>> GetResultsByClass(int classId);
        public Task<Result> GetResult(int id);
        public Task<bool> PostResult(Result Result);
        public Task<Result> PutResult(ResultViewModel ResultViewModel);
        public Task<Result> DeleteResult(int id);
    }
}
