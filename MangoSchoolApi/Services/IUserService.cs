namespace MangoSchoolApi.Services
{
    public interface IUserService
    {
        public Task<bool> processInvite(string email);
    }
}
