using Bank.InputBlocks;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataInputBlocks
{
    
    public class UserDetailFetcherInputBlock<T> : InputBlockTransferInterface<T>
    {
        public T GetTransactionInputBlock() {

            long accountNumber;

            Console.WriteLine("Enter the Account Number to Fetch Details  : ");
            accountNumber = Convert.ToInt64(Console.ReadLine());

            return (T)(Object) accountNumber;
        }
    }
}
