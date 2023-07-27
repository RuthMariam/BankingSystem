using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class AddAccountUI : IUserInterface
    {
        public void DisplayAndInvoke()
        {
            Console.Clear();
            try
            {

                Menu mainMenu = new Menu()
                {
                    MenuListItems = { "ADD ACCOUNT VIA CONSOLE", "ADD ACCOUNT VIA FILE"},
                    menuTitle = "ACCOUNT CREATION PAGE"
                };
                mainMenu.MenuDisplay();

                int choice = DataProcessor.ValidateInteger(Console.ReadLine());
                IAccountSetupService? service = null;


                switch (choice)
                {
                    case 1:
                        service = AccountFactory.CreateAccount(CreationMode.Console);

                        break;
                    case 2:
                        service = AccountFactory.CreateAccount(CreationMode.File);
                        break;
                }

                TransactionManager am = new TransactionManager();

                int flag = am.Process(service);
                Console.WriteLine($"{flag} account created successfully.");
                Console.ReadLine();




            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
