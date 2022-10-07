using System;
using System.Collections.Generic;

namespace CustomerManagementSystem.Models
{
    public partial class Dependancy
    {
        public int Deptid { get; set; }
        public int? Custid { get; set; }
        public string Depententname { get; set; }
        public string Feature { get; set; }

        public Customer Cust { get; set; }
    }
}
