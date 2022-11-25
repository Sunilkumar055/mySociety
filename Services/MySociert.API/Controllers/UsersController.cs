using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySociety.BAL.Repository;
using MySociety.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySociert.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Without repo patter
        //private readonly ApplicationDBContext _societyDBContext;

        //public UsersController(ApplicationDBContext societyDBContext)
        //{
        //    _societyDBContext = societyDBContext;
        //}

        //[HttpGet]
        //[Route("GetUsers")]
        //public IActionResult GetUsers()
        //{
        //    var users = _societyDBContext.users.ToList();
        //    return Ok(users);
        //}[HttpGet]
        #endregion
        readonly IUserRepository userRepository;

        public UsersController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await userRepository.GetUsers();
                if (users is null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(long? userId)
        {
            if (userId == null)
            {
                return BadRequest();
            }
            try
            {
                var user = await userRepository.GetUserById(userId);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> AddUser([FromBody] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userid = await userRepository.AddUser(userModel);
                    if (userid > 0)
                        return Ok(userid);
                    else
                        return NotFound();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(long? userId)
        {
            if (userId == null)
            {
                return BadRequest();
            }
            try
            {
                var user = await userRepository.DeleteUser(userId);
                if (user == 0)
                    return NotFound();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await userRepository.UpdateUser(userModel);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
