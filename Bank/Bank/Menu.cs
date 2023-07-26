using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Menu{

        public string menuTitle = "";
        public List<string> MenuListItems = new List<string>();

        void AddTitleText(string sidesDisplaySpace){
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{sidesDisplaySpace}{menuTitle}{sidesDisplaySpace}");
            Console.ResetColor();
        }

        public void DisplayLogoUi(){
            string logoForAllPage = "                   __             __  \r\n _______ ________ / /  ___ ____  / /__\r\n/ __/ _ `/ __/ -_) _ \\/ _ `/ _ \\/  '_/\r\n\\__/\\_,_/_/  \\__/_.__/\\_,_/_//_/_/\\_\\ \r\n                                      ";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(logoForAllPage);
            Console.ResetColor(); // Reset color back to default.
            
        }
        public string GetMarginSpace() {
            string sidesMarginSpace = "";

            for (int i = 0; i < Console.WindowWidth / 2 - 10; i++){
                sidesMarginSpace += " ";
            }
            return sidesMarginSpace;
        }

        public int DisplayMenuList() {
            int index = 1;
            foreach (string menuItems in MenuListItems)
            {
                Console.WriteLine("\t" + index.ToString() + ") " + menuItems);
                index++;
            }
            int obtion = Convert.ToInt32(Console.ReadLine());
            if (obtion < index && obtion > 0)
            {
                return obtion;
            }
            else {
                throw new Exception("Invalid option");
            }
        }

        

        public int MenuDisplayAndSelect()
        {
            Console.Clear();
            
            DisplayLogoUi();
            string margin = GetMarginSpace();
            AddTitleText(margin);
            int selectedOption = DisplayMenuList();
            return selectedOption;

        }
        public void MenuDisplay() { 
        }

        


    }
}
