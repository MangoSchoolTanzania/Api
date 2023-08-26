namespace MangoSchoolApi.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  Year { get; set; }
        public int Semester { get; set; }

        /// <summary>
        /// Nav Props
        /// </summary>
        public ICollection<Student> Students { get; set; } 
        public ICollection<Result> Results { get; set; }
    }
}
