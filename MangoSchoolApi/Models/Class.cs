namespace MangoSchoolApi.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } 
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTimeOffset CreateDate { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}
