// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Xml;
namespace Bank
{
    public interface IRead
    {
        int AddAccount();
    }

    public interface IDataBase
    {
        Account Fetch(long AccountNumber);
        void Write(Account account);
        void Modify(Account account);
    }



    public class ReadFromConsole : IRead
    {
        Account account { get; set; }
        public ReadFromConsole(Account account)
        {
            this.account = account;
        }
        public int AddAccount()
        {
            IDataBase dataBase = new JsonDatabase();

            Account fetchAcc = dataBase.Fetch(account.AccountNumber);
            if (fetchAcc == null)
            {
                dataBase.Write(account);
                return 1;

            }
            else
            {
                return 0;
            }

        }

    }

    public class ReadFromFile : IRead
    {
        public string filePath { get; set; }
        public ReadFromFile(string filename)
        {
            filePath = $"{Environment.CurrentDirectory}\\{filename}";
        }
        public int AddAccount()
        {
            IDataBase dataBase = new JsonDatabase();
            int CountForCreatedAccount = 0;
            foreach (string line in File.ReadLines(filePath))
            {
                string[] details = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                Account account = new Account(details[0]);
                account.AccountNumber = Convert.ToInt64(details[1]);
                account.Balance = Convert.ToDouble(details[2]);
                account.Currency = details[3];

                Account fetchAcc = dataBase.Fetch(account.AccountNumber);
                if (fetchAcc == null)
                {
                    dataBase.Write(account);
                    CountForCreatedAccount++;
                }


            }
            return CountForCreatedAccount;
        }
    }

}
   