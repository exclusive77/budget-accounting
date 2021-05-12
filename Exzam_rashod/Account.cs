using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
namespace Exzam_rashod
{
    public class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<consumption> consumption { get; set; }
        
        public User user { get; set; }
    }
}
