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
    public class JsonDatabase : IDataBase
    {
        public static string directoryPath = $"{Environment.CurrentDirectory}\\JSON_DB";
        public Account Fetch(long AccountNumber)
        {
            string fileName = $"{AccountNumber}.json";
            string searchFolder = $"{AccountNumber.ToString()[0]}";
            string subfolderPath = Path.Combine(directoryPath, searchFolder);

            if (!Directory.Exists(subfolderPath))
                return null; //ACCOUNT DOESNT EXIST

            string filePath = Path.Combine(directoryPath, searchFolder, fileName);
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string jsonString = sr.ReadToEnd();
                    var requestedAccount = JsonConvert.DeserializeObject<Account>(jsonString);
                    return requestedAccount;
                }
            }
            return null;    //ACCOUNT DOESNT EXIST
        }
        public void Write(Account account)
        {
            string jsonString = JsonConvert.SerializeObject(account, Newtonsoft.Json.Formatting.Indented);

            //CREATION OF FOLDER WITH NAME AS JSON DATABASE
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            //CREATION OF SUB FOLDERS
            string subFolder = $"{account.AccountNumber.ToString()[0]}";
            string subfolderPath = Path.Combine(directoryPath, subFolder);
            if (!Directory.Exists(subfolderPath))
                Directory.CreateDirectory(subfolderPath);

            //FILE FOR EACH ACCOUNT
            string filePathnew = $"{Environment.CurrentDirectory}\\JSON_DB\\{subFolder}\\{account.AccountNumber}.json";
            if (!File.Exists(filePathnew))
                File.AppendAllText(filePathnew, jsonString);
        }


        public void Modify(Account account)
        {
            string jsonString = JsonConvert.SerializeObject(account, Newtonsoft.Json.Formatting.Indented);
            string subFolderName = $"{account.AccountNumber.ToString()[0]}";
            string filePathnew = $"{Environment.CurrentDirectory}\\JSON_DB\\{subFolderName}\\{account.AccountNumber}.json";
            if (File.Exists(filePathnew))
                File.WriteAllText(filePathnew, jsonString);
        }
    }

}