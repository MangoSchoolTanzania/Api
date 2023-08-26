namespace MangoSchoolApi.Models
{
    public class Result
    {
        public int Id { get; set; }
        public float result { get; set; }

        /// <summary>
        /// Nav Props
        /// </summary>
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
