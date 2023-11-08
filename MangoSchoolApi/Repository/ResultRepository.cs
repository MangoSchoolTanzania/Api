using MangoSchoolApi.Data;
using MangoSchoolApi.Models;
using MangoSchoolApi.Models.ModelView;
using MangoSchoolApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace MangoSchoolApi.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly MangoDataContext _MangoDataContext;

        public ResultRepository(MangoDataContext MangoDataContext)
        {
            _MangoDataContext = MangoDataContext;
        }

        public async Task<List<ResultModelView>> GetResults(int page, string filterSelectedPage, string? stringParam)
        {

            if (filterSelectedPage == "All")
            {
                var results = await _MangoDataContext.Results
               .Include(x => x.Class)
               .Where(x => x.IsActive == true)
               .OrderByDescending(x => x.Class.CreateDate)
               .ThenByDescending(x => x.Class.Name)
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

                return results;
            }

            if (filterSelectedPage == "Class")
            {
                var results = await _MangoDataContext.Results
                .Include(x => x.Class)
                .Where(x => x.IsActive == true && x.Class.Name.Contains(stringParam))
                .OrderByDescending(x => x.Class.CreateDate)
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

                return results;
            }

            if (filterSelectedPage == "Year")
            {
                var results = await _MangoDataContext.Results
                .Include(x => x.Class)
                .Where(x => x.IsActive == true && x.Class.Year == int.Parse(stringParam))
                .OrderByDescending(x => x.Class.CreateDate)
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

                return results;
            }

            if (filterSelectedPage == "Student")
            {
                var results = await _MangoDataContext.Results
                .Include(x => x.Class)
                .Where(x => x.IsActive == true && x.Name == stringParam)
                .OrderByDescending(x => x.Class.CreateDate)
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

                return results;
            }

            return new List<ResultModelView>();
        }

        public async Task<List<ResultModelView>> GetResultsByClass(int classId)
        {
            var results = await _MangoDataContext.Results
                   .Where(x => x.ClassId == classId)
                   .Include(x => x.Class)
                   .OrderByDescending(x => x.CreateDate)
                   .ThenByDescending(x => x.Name)
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

            return results;
        }

        public async Task<Result> GetResult(int id)
        {
            var clasS = await _MangoDataContext.Results
                    .Where(x => x.IsActive == true)
                    .FirstOrDefaultAsync(c => c.Id == id);


            return clasS;
        }

        public async Task<bool> PostResult(Result Result)
        {
            var result = _MangoDataContext.Results.Add(Result);
            _MangoDataContext.SaveChanges();
            return true;
        }


        public async Task<Result> PutResult(ResultViewModel ResultViewModel)
        {
            var ClassFromDataBase = _MangoDataContext.Results.FirstOrDefault(c => c.Id == ResultViewModel.Id);
            
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

            return ClassFromDataBase;
        }

        public async Task<Result> DeleteResult(int id)
        {

            var resultFromDatabase = _MangoDataContext.Results.FirstOrDefault(x => x.Id == id);

            _MangoDataContext.Remove(resultFromDatabase);
            _MangoDataContext.SaveChanges();

            return resultFromDatabase;
        }

    }
}
