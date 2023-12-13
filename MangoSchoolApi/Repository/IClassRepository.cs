using MangoSchoolApi.Models.Models;
using MangoSchoolApi.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MangoSchoolApi.Repository
{
    public interface IClassRepository
    {
        public Task<List<Class>> GetClasses(int page);

        public Task<Class> GetClass(int id);

        public Task<Class> PostClass(Class clasS);

        public Task<Class> DeleteClass(int id);

        public Task<Class> PutClass(ClassViewModel ClassViewModel);
    }
}
