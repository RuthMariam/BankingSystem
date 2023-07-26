using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Account
    {
        public long AccountNumber { get; set; }
        public Customer customer { get; set; }
        public double Balance { get; set; }
        public string Currency { get; set; }

        public Account(string name)
        {
            this.customer = new Customer();
            customer.Name = name;
        }

    }

}
