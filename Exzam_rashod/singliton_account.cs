using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Exzam_rashod
{
    class singliton_account:IRepository<Account>
    {
        List<Account> account = new List<Account>();
        private static singliton_account instance;

        private singliton_account()
        {

        }

        public static singliton_account GetInstance()
        {
            if (instance is null)
            {
                instance = new singliton_account();
            }
            return instance;
        }

       
            MyDbContext db = new MyDbContext();
            public void Create(Account item)
            {
                db.Accounts.Add(item);
                db.SaveChanges();
            }

            public void Delete(int id)
            {
                var _account = db.Accounts.FirstOrDefault(u => u.Id == id);
                if (_account != null)
                {
                    //db.Users.Remove(user);
                    db.Entry(_account).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }

            public Account Get(int id)
            {
                return db.Accounts.FirstOrDefault(u => u.Id == id);
            }

            public IEnumerable<Account> GetAll()
            {
                return db.Accounts.ToList();
            }

            public IEnumerable<Account> GetAll(Func<Account, bool> predicate)
            {
                return db.Accounts.Where(predicate).ToList();
            }

            public void Update(Account item)
            {
                var _account = db.Accounts.FirstOrDefault(u => u.Id == item.Id);
                if (_account != null)
                {
                _account.Login = item.Login;
                _account.Password = item.Password;
                _account.user = item.user;
                _account.consumption = item.consumption;

                    db.Entry(_account).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        








    }
}
