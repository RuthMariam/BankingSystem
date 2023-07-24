using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Menu
    {
        public string menuTitle = "";
        public List<string> MenuListItems = new List<string>();
        string logoForAllPage = "                   __             __  \r\n _______ ________ / /  ___ ____  / /__\r\n/ __/ _ `/ __/ -_) _ \\/ _ `/ _ \\/  '_/\r\n\\__/\\_,_/_/  \\__/_.__/\\_,_/_//_/_/\\_\\ \r\n                                      ";


        public void MenuDisplay()
        {
            Console.Clear();

            string begDisplaySpace = "";
            string endDisplaySpace = "";
            for (int i = 0; i < Console.WindowWidth / 2 - 10; i++)
            {
                begDisplaySpace += " ";
            }
            for (int i = 0; i < Console.WindowWidth / 2 - menuTitle.Length; i++)
            {
                endDisplaySpace += " ";
            }

            if (menuTitle != "ADMIN PAGE")
            {
                Console.WriteLine(logoForAllPage);
            }
            else
            {
                DisplayLogoUi();
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{begDisplaySpace}{menuTitle}{endDisplaySpace}");
            Console.ResetColor();

            int index = 1;
            foreach (string menuItems in MenuListItems)
            {
                Console.WriteLine("\t" + index.ToString() + ") " + menuItems);
                index++;
            }

            

        }



        public void DisplayLogoUi()
        {
            string bankName = "    __   ____  ____     ___  ____    ____  ____   __  _ \r\n   /  ] /    ||    \\   /  _]|    \\  /    ||    \\ |  |/ ]\r\n  /  / |  o  ||  D  ) /  [_ |  o  )|  o  ||  _  ||  ' / \r\n /  /  |     ||    / |    _]|     ||     ||  |  ||    \\ \r\n/   \\_ |  _  ||    \\ |   [_ |  O  ||  _  ||  |  ||     \\\r\n\\     ||  |  ||  .  \\|     ||     ||  |  ||  |  ||  .  |\r\n \\____||__|__||__|\\_||_____||_____||__|__||__|__||__|\\_|\r\n                                                        ";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("             _                    _        \r\n __ __ _____| |__ ___ _ __  ___  | |_ ___  \r\n \\ V  V / -_) / _/ _ \\ '  \\/ -_) |  _/ _ \\ \r\n  \\_/\\_/\\___|_\\__\\___/_|_|_\\___|  \\__\\___/ \r\n                                           ");
            Console.ResetColor(); // Reset color back to default.
            Console.WriteLine(bankName);
        }


    }
}
