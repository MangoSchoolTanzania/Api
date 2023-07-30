namespace MangoSchoolApi.Models
{
    public class Result
    {
        public int Id { get; set; }
        public float result { get; set; }
        public Studant Studant { get; set; }
        public Class Class { get; set; }
    }
}
