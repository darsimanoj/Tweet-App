
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
        private IJavaScriptService _javaScriptService;

        //TweetDataContext db = new TweetDataContext();
        public UserController(IUserRepository uRepository, IJavaScriptService javaScriptService) { _userRepository = uRepository; _javaScriptService = javaScriptService; }

            // GET api/<ValuesController>/5
            /* [HttpGet] 
             public IEnumerable<Users> Get()
             {
                 List<Users> l = db.Users.ToList();
                 return l;
             }*/

        [HttpGet("{email}")]
        public bool Get(string email)
        {
            return _userRepository.ValidateEmail(email);
        }
        [HttpGet("hello")]
        public async Task<IActionResult> Hello()
        {
            string ret = await _javaScriptService.Hello("Michael");
            return Ok(ret);
        }

        [Route("LoggedReset")]
        [HttpPost]
        public bool Post([FromBody] List<string> user)
        {
            bool s =_userRepository.verifyOldPassword(user[0], user[1]);
            if(s)
            {
                return _userRepository.UpdatePassword(user[0], user[2]);
            }
            return s;
        }
        [Route("Register")]
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
        public Info Post([FromBody] Login  login)
        {
            Users u = _userRepository.VerifyLogin(login);
            if (u == null)
            {
                return null;
            }
            else
            {
                return new Info() { Id = (int) u.UId, Username = u.Email };
            }
            
        }

        [Route("Logout")]
        [HttpPost]
        public bool Post([FromBody] int id)
        {
            return _userRepository.Logout(id);

        }
        // PUT api/<ValuesController>/5
        [HttpPut("{email}")]
        public bool Put(string email,[FromBody] string password)
        {
           
                
                return _userRepository.UpdatePassword(email, password);
            
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
