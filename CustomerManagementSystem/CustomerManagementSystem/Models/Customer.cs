using System;
using System.Collections.Generic;

namespace CustomerManagementSystem.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Dependancy = new HashSet<Dependancy>();
        }

        public int Custid { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Dependancy> Dependancy { get; set; }
    }
}
