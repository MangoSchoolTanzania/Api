using MangoSchoolApi.Data;
using MangoSchoolApi.Models;
using MangoSchoolApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangoSchoolApi.Controllers
{
    [ApiController]
    [Route("v1/User")]
    public class UserController : ControllerBase
    {
        private readonly MangoDataContext _MangoDataContext;
        public UserController(MangoDataContext MangoDataContext)
        {
            _MangoDataContext = MangoDataContext;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _MangoDataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user == null) { return NotFound(); }

                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet("{page}")]
        public async Task<IActionResult> GetUsers(int page)
        {
            try
            {
                var users = await _MangoDataContext.Users
                    .Where(x => x.isActive)
                    .Skip(10 * page)
                    .Take(10)
                    .ToListAsync();

                return Ok(users);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize, HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserViewModel UserViewModel)
        {
            try
            {
                if (UserViewModel == null) { return NotFound(); }

                var user = new User()
                {
                    isActive = true,
                    Password = UserViewModel.Password,
                    UserEmail = UserViewModel.UserEmail,
                    UserName = UserViewModel.UserName,
                    isAdmin = UserViewModel.isAdmin
                };

                _MangoDataContext.Add(user);
                _MangoDataContext.SaveChanges();

                return Ok(UserViewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize, HttpPut]
        public async Task<IActionResult> PutUser([FromBody]UserViewModel UserViewModel)
        {
            try
            {
                if (UserViewModel == null) return NotFound();
                var UserFromDatabase = await _MangoDataContext.Users.FirstAsync(x => x.Id == UserViewModel.Id);
                if (UserFromDatabase == null) return NotFound();

                UserFromDatabase.isAdmin = UserViewModel.isAdmin;
                UserFromDatabase.UserEmail = UserViewModel.UserEmail;
                UserFromDatabase.Password = UserViewModel.Password;
                UserFromDatabase.UserName = UserViewModel.UserName;

                _MangoDataContext.Update(UserFromDatabase);
                _MangoDataContext.SaveChanges();

                return Ok(UserFromDatabase);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize, HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _MangoDataContext.Users.FirstAsync(x => x.Id == id);
                if(user == null) return NotFound();

                user.isActive = false;

                _MangoDataContext.Update(user);
                _MangoDataContext.SaveChanges();

                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
