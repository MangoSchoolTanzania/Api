using MangoSchoolApi.Models.Models;
using MangoSchoolApi.Models.ViewModel;

namespace MangoSchoolApi.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> PostUser(User user);
        Task<User> PutUser(int id, UserViewModel user);
        Task<User> DeleteUser(int id);
    }
}
