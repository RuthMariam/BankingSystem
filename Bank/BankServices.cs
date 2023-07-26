using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;
using BankProcessingLibrary;

namespace Bank
{
    public class TransactionManager
    {
        private readonly IBankProcess bp;

        public TransactionManager(IBankProcess? bp) {
            this.bp = bp;
        }

        public Account MakeTransaction()
        {
            return bp.Process();


        }
    }
}
