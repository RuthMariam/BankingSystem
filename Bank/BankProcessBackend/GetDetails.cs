using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Bank.BankProcessBackend
{
    public class GetDetailsConsole : IGetDetails
    {
        long accNo;
        private readonly IDataBase db;

        public GetDetailsConsole(long accNo)
        {
            this.accNo = accNo;
            db = new JsonDatabase();
        }

        public Account GetDetail()
        {
            Account account = db.Fetch(accNo);
            if (account != null)
            {
                return account;
            }
            else { throw new InvalidAccountNumberException(accNo.ToString()); }
        }
    }
}
