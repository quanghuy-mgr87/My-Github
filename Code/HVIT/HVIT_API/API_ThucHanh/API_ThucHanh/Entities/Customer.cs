using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ThucHanh.Entities
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string phoneNumber { get; set; }
        public virtual IEnumerable<Bill> Bills { get; set; }
        public Customer() { }
    }
}
