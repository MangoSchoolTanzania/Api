﻿using MangoSchoolApi.Data;
using MangoSchoolApi.Models;
using MangoSchoolApi.Models.Models;
using MangoSchoolApi.Models.ViewModel;
using MangoSchoolApi.Repository;
using MangoSchoolApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangoSchoolApi.Controllers
{
    [ApiController]
    [Route("v1/User/")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _IUserRepository;
        private readonly IUserService _IUserService;

        public UserController(IUserRepository UserRepository, IUserService IUserService)
        {
            _IUserRepository = UserRepository;
            _IUserService = IUserService;
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _IUserRepository.GetUser(id);

                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _IUserRepository.GetUsers();

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

                var UserSaved = _IUserRepository.PostUser(user);

                return Ok(UserSaved);
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
                var user = _IUserRepository.PutUser(UserViewModel.Id,UserViewModel);

                return Ok(user);
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
                var user = await _IUserRepository.DeleteUser(id);

                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize, HttpPost,Route("Invite")]
        public async Task<IActionResult> InviteNewUser([FromBody]InviteViewModel Invite)
        {
            try
            {
               return Ok(await _IUserService.processInvite(Invite.Email)); 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
