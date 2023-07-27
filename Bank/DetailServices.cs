using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace Bank
{
    public class DetailManager
    {
        private readonly IAccountService gd;

        public DetailManager(IAccountService gd)
        {
            this.gd = gd;
        }

        public Account MakeTransaction()
        {
            return gd.GetDetail();

        }
    }
}
