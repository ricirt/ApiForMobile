using ApiForMobile.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("Register")]
        public IActionResult RegisterUser(User user)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                if (ModelState.IsValid)
                {
                    var addedEntity = context.Entry(user);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginModel model)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user != null)
                {
                    if (user.Password.Equals(model.Password))
                        return Ok();
                    else
                        return StatusCode(403);
                }
                else
                {
                    return StatusCode(404);
                }
            }
        }
        [HttpGet("GetUserById")]
        public IActionResult GetUserById([FromQuery]int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                //var user = context.Users.Find(id);
                var user = context.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                //var user = context.Users.Find(id);
                var user = context.Users.ToList();
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
