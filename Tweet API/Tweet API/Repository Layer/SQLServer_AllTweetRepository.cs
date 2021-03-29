using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweet_API.Models;

namespace Tweet_API.Repository_Layer
{
    public class SQLServer_AllTweetRepository : IAllTweetRepository
    {
        private readonly TweetDataContext db;

        public SQLServer_AllTweetRepository(TweetDataContext dbContext)
        {
            this.db = dbContext;
        }
        public List<AllTweets> GetAllTweets()
        {
            return db.AllTweets.ToList();
        }
    }
}
