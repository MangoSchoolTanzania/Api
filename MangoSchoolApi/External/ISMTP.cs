namespace MangoSchoolApi.External
{
    public interface ISMTP
    {
        public Task<bool> SendEmail(string email,Guid guid);
    }
}
