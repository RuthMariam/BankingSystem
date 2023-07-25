using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class AccountMananger
    {
        private readonly IAddAccount ad;

        public AccountMananger(IAddAccount ad)
        {
            this.ad = ad;
        }
        public int AccountCreation()
        {
            return ad.AddAccount();
        }
    }
}
