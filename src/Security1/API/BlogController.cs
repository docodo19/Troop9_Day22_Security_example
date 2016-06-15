using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Security1.Data;
using Microsoft.AspNetCore.Identity;
using Security1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Security1.API
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public BlogController(
            ApplicationDbContext db, 
            UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }



        // GET: api/values
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var userId = _userManager.GetUserId(this.User);
            var currentUser = _db.Users.Where(u => u.Id == userId).Include(u => u.Blogs).FirstOrDefault();

            return Ok(currentUser.Blogs);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
