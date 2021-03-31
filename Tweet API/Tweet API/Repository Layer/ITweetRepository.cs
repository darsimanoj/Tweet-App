using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweet_API.Models;

namespace Tweet_API.Repository_Layer
{
    public interface ITweetRepository
    {
        bool Tweet(Tweets tweet);
        public List<String> GetUserTweets(int id);

        public Hashtable GetUsersandTweets();
    }
}
