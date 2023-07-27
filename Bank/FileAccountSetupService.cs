using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Bank
{
    public class FileAccountSetupService : IAccountSetupService
    {
        //public ReadfromFile() { }
        //public bool AddAccount()
        //{
        //    //read file name here

        //    return true;
        //}

        public string filename;
        public FileAccountSetupService(string path)
        {
            filename = path;
        }
        public int AddAccount()
        {
            IRead Input = new ReadFromFile(filename);
            int noAccCreated = Input.AddAccount();
            if (noAccCreated == 0)
            {
                throw new AccountAlreadyExistsException(noAccCreated);
            }
            return noAccCreated;
        }
    }
}
