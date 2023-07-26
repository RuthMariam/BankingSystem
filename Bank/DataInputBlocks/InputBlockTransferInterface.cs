using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.InputBlocks
{
    public interface InputBlockTransferInterface<T>
    {
        public T GetTransactionInputBlock();

    }

}
