using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweet_API.DTO;
using Tweet_API.Models;
using Tweet_API.Repository_Layer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tweet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       public readonly IUserRepository _userRepository;
        TweetDataContext db = new TweetDataContext();
        public UserController(IUserRepository uRepository) => _userRepository = uRepository;

        // GET api/<ValuesController>/5
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            List<Users> l = db.Users.ToList();
            return l;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] UserDTO user)
        {
            Users u = new Users
            {
                FirstName = user.FirstName,
                Lastname = user.Lastname,
                Gender = user.Gender,
                Dob = user.Dob,
                Email = user.Email,
                Password = user.Password
            };
            _userRepository.Add(u);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
