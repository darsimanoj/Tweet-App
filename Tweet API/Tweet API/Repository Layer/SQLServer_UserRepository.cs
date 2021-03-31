

using System.Linq;

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

        public bool ValidateEmail(string email)
        {
            return (db.Users.FirstOrDefault(x => x.Email == email) != null) ? true : false;
        }

        public Users VerifyLogin (Login login) 
        {
            Users user = db.Users.FirstOrDefault(x =>  x.Email == login.username && x.Password == login.password);
            if (user == null) {
                return null;
            }
            user.LoggedInStatus = true;

            db.Users.Update(user);
            int res = db.SaveChanges();
            return res > 0 ? user : null;
        }


        public bool DeleteUser (int Id)
        {
            Users use = db.Users.FirstOrDefault(x => x.UId == Id);
            db.Users.Remove(use);
            int res = db.SaveChanges();
            return res > 0 ? true : false;
        }

        public bool UpdatePassword(string email, string password)
        {
           
                Users user = db.Users.FirstOrDefault(x => x.Email == email);
                user.Password = password;
                db.Users.Update(user);
                int res = db.SaveChanges();
                return res > 0 ? true : false;
            
        }

        public bool Logout(int id)
        {
            Users u = db.Users.FirstOrDefault(x => x.UId == id);
            u.LoggedInStatus = false;
            int res = db.SaveChanges();
            return res > 0 ? true : false;
        }
    }
}
