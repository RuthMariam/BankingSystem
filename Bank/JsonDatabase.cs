using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
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

