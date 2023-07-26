using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
namespace Bank
{
    public class Withdraw : IBankProcess
    {
        long accNo;
        double amt;
        private readonly IDataBase db;

        public Withdraw(long accNo, double amt)
        {
            this.accNo = accNo;
            this.amt = amt;
            db = new JsonDatabase();
        }
        public Account Process()
        {
            Account acc = db.Fetch(accNo);
            if (acc == null)
            {
                throw new InvalidAccountNumberException(accNo.ToString());
            }
            else
            {
                if (acc.Balance < amt)
                {
                    throw new InsufficientBalanceException(accNo.ToString());
                }
                else
                {
                    acc.Balance -= amt;
                }
                db.Modify(acc);
                return acc;
            }
        }
    }
}
