using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Transfer : IAccountTransactionService
    {
        long fromAccNo, toAccNo;
        double amt;
        private readonly IDataBase db;

        public Transfer(long fromAccNo, long toAccNo, double amt)
        {
            this.fromAccNo = fromAccNo;
            this.toAccNo = toAccNo;
            this.amt = amt;
            db = new JsonDatabase();
        }
        public Account Process()
        {
            Account From = db.Fetch(fromAccNo);
            Account To = db.Fetch(toAccNo);

            if (From == null)
            {
                throw new InvalidAccountNumberException(fromAccNo.ToString());
            }
            else if (To == null)
            {
                throw new InvalidAccountNumberException(toAccNo.ToString());
            }
            else
            {
                if (From.Balance < amt)
                {
                    throw new InsufficientBalanceException(fromAccNo.ToString());
                }
                From.Balance -= amt;
                To.Balance += amt;
                db.Modify(From);
                db.Modify(To);
                return From;
            }
        }
    }
}
