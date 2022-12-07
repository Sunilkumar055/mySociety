using Microsoft.AspNetCore.Mvc;
using MySociety.BAL.Interface;
using MySociety.BAL.Repository;
using MySociety.Common.Configurations;
using MySociety.Common.Model;
using System;
using System.Threading.Tasks;

namespace MySocietyAPI.Controllers
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
        readonly IAuthManager authManager;
        
        public UsersController(IAuthManager authManager)
        {
            this.authManager = authManager;            
        }

        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = authManager.GetUsers();
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
        public IActionResult GetUserById(long userId = 0)
        {
            if (userId == 0)
            {
                return BadRequest();
            }
            try
            {
                var user = authManager.GetUsers(userId);
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
        public async Task<IActionResult> AddUser([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userid = await authManager.AddUser(user);
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
        public async Task<IActionResult> DeleteUser(long userId)
        {
            if (userId <= 0)
            {
                return BadRequest();
            }
            try
            {
                var user = await authManager.DeleteUser(userId);
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
        public async Task<IActionResult> UpdateUser(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await authManager.UpdateUser(user);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [Route("Roles")]
        public IActionResult GetRole(int RoleID = 0)
        {
            try
            {
                var roles = authManager.GetRole(RoleID);
                if (roles == null)
                    return NotFound();

                return Ok(roles);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
