using MangoSchoolApi.Data;
using MangoSchoolApi.Models.Models;
using MangoSchoolApi.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangoSchoolApi.Repository
{
    public class ClassRepository : IClassRepository
    {
        public readonly MangoDataContext _MangoDataContext;

        public ClassRepository(MangoDataContext MangoDataContext)
        {
            _MangoDataContext = MangoDataContext;
        }

        public async Task<List<Class>> GetClasses(int page)
        {
            var classes = await _MangoDataContext.Classes
                    .Skip(10 * page)
                    .Take(10)
                    .OrderByDescending(x => x.CreateDate)
                    .ToListAsync();

            return classes;
        }

        public async Task<Class> GetClass(int id)
        {
            var clasS = await _MangoDataContext.Classes
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (clasS == null) return new Class();

            return clasS;
        }
        public async Task<Class> PostClass(Class clasS)
        {
            _MangoDataContext.Classes.Add(clasS);
            _MangoDataContext.SaveChanges();

            return clasS;
        }

        public async Task<Class> DeleteClass(int id)
        {
            var clasS = await _MangoDataContext.Classes.FirstOrDefaultAsync(c => c.Id == id);

            _MangoDataContext.Remove(clasS);
            _MangoDataContext.SaveChanges();

            return clasS;
        }

        public async Task<Class> PutClass(ClassViewModel ClassViewModel)
        {
            var clasS = await _MangoDataContext.Classes.FirstOrDefaultAsync(x => x.Id == ClassViewModel.Id);

            clasS.Year = ClassViewModel.Year;
            clasS.Month = ClassViewModel.Month;
            clasS.Name = ClassViewModel.Name;
            _MangoDataContext.Update(clasS);
            _MangoDataContext.SaveChanges();

            return clasS;
        }

    }
}
