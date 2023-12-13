using MangoSchoolApi.External;
using MangoSchoolApi.Models;
using MangoSchoolApi.Models.Models;
using MangoSchoolApi.Repository;

namespace MangoSchoolApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISMTP _smtp;
        private Guid CreatedGuid;
        public UserService(IUserRepository userRepository, ISMTP smtp)
        {
            _userRepository = userRepository;
            _smtp = smtp;
        }

        public async Task<bool> processInvite(string email)
        {
            var wasCreatedANewUser = await CreateNewUser();
            var wasSentANewEmail = await sendEmail(email);

            if(wasCreatedANewUser && wasSentANewEmail)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> sendEmail(string email)
        {
            try
            {
                _smtp.SendEmail(email,CreatedGuid);
                return true;
            }
            catch (Exception)
            {
                return false;
            }   
        }

        public async Task<bool> CreateNewUser()
        {
            var user = new User()
            {
                UserName = Guid.NewGuid().ToString(),
                UserEmail = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString(),
                isAdmin = true,
                InviteGuid = Guid.NewGuid(),
                isActive = false,
            };

            var savedUser = await _userRepository.PostUser(user);

            if(savedUser != null)
            {
                CreatedGuid = savedUser.InviteGuid;
                return true;
            }

            return false;
        }
    }
}
