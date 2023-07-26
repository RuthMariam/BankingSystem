using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.InputBlocks
{
    class TransferInputData {
        public double transferAmt;
        public long senderAccNumber;
        public long recipentAccNumber;
    }
    internal class TransferInputReader<T> : InputBlockTransferInterface<T>
    {
        
        public T GetTransactionInputBlock() {

            TransferInputData transferInputData = new TransferInputData();

            Console.Write("Enter the Sender Account Number  : ");
            transferInputData.senderAccNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter the Reciepent Account Number  : ");
            transferInputData.recipentAccNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter amount to be transferred  : ");
            transferInputData.transferAmt = Convert.ToDouble(Console.ReadLine());

            return (T)(object) transferInputData;
        }
    }
}
