using System;
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
        public bool Add(Tweets tweet)
        {
            db.Add(tweet);
            int res = db.SaveChanges();
            return res > 0 ? true : false;
        }


    }
}
