using MangoSchoolApi.Data;
using MangoSchoolApi.Models;
using MangoSchoolApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MangoSchoolApi.Controllers
{
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("/v1/login")]
        public IActionResult Login([FromServices] MangoDataContext context, [FromBody]LoginViewModel credentials)
        {
            try
            {
                if(credentials == null) { return StatusCode(400, " The credentials provided are not valid"); }

                var userContext = context.Users.Where(x => x.UserEmail == credentials.Email && x.Password == credentials.Password).FirstOrDefault();

                if (userContext == null) { return StatusCode(400, " No user was found"); };

                var user = new User();
                user = userContext;

                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
