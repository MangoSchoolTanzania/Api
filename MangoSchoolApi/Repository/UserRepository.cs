using MangoSchoolApi.Data;
using MangoSchoolApi.Models;
using MangoSchoolApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangoSchoolApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MangoDataContext _MangoDataContext;

        public UserRepository(MangoDataContext MangoDataContext)
        {
            _MangoDataContext = MangoDataContext;
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                var users = await _MangoDataContext
                    .Users
                    .OrderBy(x => x.UserName)
                    .ToListAsync()
                    ;

                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                var user = await _MangoDataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> DeleteUser(int id)
        {
            try
            {
                var user = GetUser(id);
                _MangoDataContext.Remove(user);
                _MangoDataContext.SaveChanges();
                return await user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> PutUser(int id, UserViewModel user)
        {
            try
            {
                var existingUser = await _MangoDataContext.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (existingUser != null)
                {
                    existingUser.UserName = user.UserName;
                    existingUser.UserEmail = user.UserEmail;
                    existingUser.Password = user.Password;
                    existingUser.isAdmin = user.isAdmin;
                    existingUser.isActive = user.isActive;

                    _MangoDataContext.Update(existingUser);
                    await _MangoDataContext.SaveChangesAsync();
                }

                return existingUser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> PostUser(User user)
        {
            try
            {
                _MangoDataContext.Users.Add(user);
                await _MangoDataContext.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
