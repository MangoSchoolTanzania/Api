using MangoSchoolApi.Models;

namespace MangoSchoolApi.Models.ViewModel
{
    public class ClassViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
