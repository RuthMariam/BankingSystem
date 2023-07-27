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
        //private readonly IBankProcess bp;
        //private readonly IAddAccount ac;
        //private readonly IGetDetails gd;

        //public TransactionManager(IBankProcess? bp) {
        //    this.bp = bp;
        //}
        //public TransactionManager(IAddAccount? ac)
        //{
        //    this.ac = ac;
        //}
        //public TransactionManager(IGetDetails? bp)
        //{
        //    this.gd = bp;
        //}


        public Account Process(IAccountTransactionService bp)
        {
            return bp.Process();
        }
        public Account Process(IAccountService gd)
        {
            return gd.GetDetail();
        }
        public int Process(IAccountSetupService ac)
        {
            return ac.AddAccount();
        }
    }
}
