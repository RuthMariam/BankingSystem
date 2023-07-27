using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Deposit : IAccountTransactionService
    {
        long accNo;
        double amt;
        private readonly IDataBase db;

        public Deposit(long accNo, double amt)
        {
            this.accNo = accNo;
            this.amt = amt;
            db = new JsonDatabase();
        }
        public Account Process()
        {
            Account A = db.Fetch(accNo);
            if (A == null)
            {
                throw new InvalidAccountNumberException(accNo.ToString());
            }
            else
            {
                A.Balance += amt;
                db.Modify(A);
                return A;
            }
        }
    }
}
