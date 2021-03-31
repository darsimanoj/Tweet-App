using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweet_API.Models;
using Tweet_API.Repository_Layer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tweet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        public readonly ITweetRepository _tweetRepository;
        //TweetDataContext db = new TweetDataContext();
        public TweetController(ITweetRepository tRepository) => _tweetRepository = tRepository;

        // GET: api/<ValuesController>
        [HttpGet]
        public Hashtable Get()
        {
            return _tweetRepository.GetUsersandTweets();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IEnumerable<String> Get(int id)
        {
            return _tweetRepository.GetUserTweets(id);
        }

        // POST api/<ValuesController>
        [HttpPost("{id}")]
        public bool Post(int id, [FromBody] string value)
        
        {
            Tweets t = new Tweets() 
            {
                Content = value,
                UserId = id
            };
           return _tweetRepository.Tweet(t);
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
