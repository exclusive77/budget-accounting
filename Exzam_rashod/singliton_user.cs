using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Exzam_rashod
{
    class singliton_user
    {
        List<User> users = new List<User>();
        private static singliton_user instance;

        private singliton_user()
        {

        }

        public static singliton_user GetInstance()
        {
            if (instance is null)
            {
                instance = new singliton_user();
            }
            return instance;
        }


        MyDbContext db = new MyDbContext();
        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                
                db.Entry(user).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public IEnumerable<User> GetAll(Func<User, bool> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Update(User item)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == item.Id);
            if (user != null)
            {
                user.Firstname = item.Firstname;
                user.Lastname = item.Lastname;
              //  user.Account = item.Account;

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
        }









    }
}
