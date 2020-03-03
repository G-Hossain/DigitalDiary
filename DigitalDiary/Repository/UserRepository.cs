using DigitalDiary.Interface;
using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalDiary.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public User GetLogInInfo(string username, string password)
        {
            using (DigitalDiaryDataContext db = new DigitalDiaryDataContext())
            {
                var LogInDetails = db.Users.Where(x => x.name == username && x.password == password).SingleOrDefault();
                return LogInDetails;
            }
        }
    }
}