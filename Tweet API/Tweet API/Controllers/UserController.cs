
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Tweet_API.DTO;
using Tweet_API.Models;
using Tweet_API.Repository_Layer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tweet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
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
        public void  Post([FromBody] Users user)
        {
            _userRepository.Add(user);
            /* Users user = new Users
             {
                 FirstName = use.FirstName,
                 Lastname = use.Lastname,
                 Gender = use.Gender,
                 Dob = use.Dob,
                 Email = use.Email,
                 Password = use.Password

             };*/

           /*  if (ModelState.IsValid)
                {
                     return new HttpResponseMessage(HttpStatusCode.OK);
                }
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);*/
        }
          
        

        [Route("Login")]
        [HttpPost]
        public bool Post([FromBody] Login  login)
        {
            return _userRepository.VerifyLogin(login);
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
            _userRepository.DeleteUser(id);
        }
    }
}
