namespace MangoSchoolApi.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTimeOffset CreateDate { get; set; }

        public static explicit operator Contact(Result? v)
        {
            throw new NotImplementedException();
        }
    }
}
