using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Exzam_rashod
{
    class singliton_consumption
    {  
        List<consumption> _consumptions = new List<consumption>();
        private static singliton_consumption instance;

        private singliton_consumption()
        {

        }

        public static singliton_consumption GetInstance()
        {
            if (instance is null)
            {
                instance = new singliton_consumption();
            }
            return instance;
        }


        MyDbContext db = new MyDbContext();
        public void Create(consumption item)
        {
            db.consumptions.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var _consumption = db.consumptions.FirstOrDefault(u => u.Id == id);
            if (_consumption != null)
            {
              
                db.Entry(_consumption).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public consumption Get(int id)
        {
            return db.consumptions.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<consumption> GetAll()
        {
            return db.consumptions.ToList();
        }

        public IEnumerable<consumption> GetAll(Func<consumption, bool> predicate)
        {
            return db.consumptions.Where(predicate).ToList();
        }

        public void Update(consumption item)
        {
            var _consumption = db.consumptions.FirstOrDefault(u => u.Id == item.Id);
            if (_consumption != null)
            {
                _consumption.consumption_name = item.consumption_name;
                _consumption.Price = item.Price;
                _consumption.DateTime = item.DateTime;

                db.Entry(_consumption).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
           
            









    }
}

