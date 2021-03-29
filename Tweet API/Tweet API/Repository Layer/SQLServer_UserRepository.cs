using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweet_API.DTO;
using Tweet_API.Models;

namespace Tweet_API.Repository_Layer
{
    public class SQLServer_UserRepository : IUserRepository
    {
        private readonly TweetDataContext db;

        public SQLServer_UserRepository(TweetDataContext dbContext)
        {
            this.db = dbContext;
        }
        public bool Add(Users user)
        {
            db.Users.Add(user);
            int res = db.SaveChanges();
            return res > 0 ? true : false;
        }

        public bool Update(Users user)
        {
            var u = db.Users.Attach(user);
            u.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            int res = db.SaveChanges();
            return res > 0 ? true : false;
        }
    }
}
