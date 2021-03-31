using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweet_API.Models;

namespace Tweet_API.Repository_Layer
{
    public class SQLServer_TweetRepository : ITweetRepository
    {

        private readonly TweetDataContext db;

        public SQLServer_TweetRepository(TweetDataContext dbContext)
        {
            this.db = dbContext;
        }
        public bool Tweet(Tweets tweet)
        {
            db.Tweets.Add(tweet);
            int res = db.SaveChanges();
            return res > 0 ? true : false;
        }

        public List<String> GetUserTweets(int id)
        {
          var t = db.Tweets.ToList().Where(x => x.UserId == id);
            List<string> s = new List<string>();
          foreach(var x in t)
            {
                s.Add(x.Content);
            }
            return s;
        }

        public Hashtable GetUsersandTweets()
        {
            var both = db.AllTweets.ToList();
            IEnumerable<string> l = both.Select(x => x.UserName).Distinct();
            Hashtable numberNames = new Hashtable();

            foreach (var x in l)
            {
                numberNames.Add(x, both.Select(x => x.Tweet));
            }
            return numberNames;
        }


    }
}
