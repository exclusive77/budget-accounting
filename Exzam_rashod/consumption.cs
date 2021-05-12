using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Exzam_rashod
{
    public class consumption
    {

        public int Id { get; set; }
        [MaxLength(200)]
        public string consumption_name { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Account Account { get; set; }
        public virtual int? AccountId { get; set; }


    }
}
