namespace MangoSchoolApi.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public bool isActive { get; set; }
    }
}
