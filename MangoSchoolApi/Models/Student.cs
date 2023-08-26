namespace MangoSchoolApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public ICollection<Result> Results { get; set; }
        public List<Class> Classes { get; set; } // Navigation property
    }
}
