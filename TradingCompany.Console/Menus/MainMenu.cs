using System;
using TradingCompany.Console.Menus;

namespace TradingCompany.Menus
{
    public static class MainMenu
    {
        public static void ShowMenu()
        {
            bool show = true;
            while(show)
            {
                //Console.Clear();
                menuInfo();
                string input = System.Console.ReadLine();
                switch (input)
                {
                    case "1":
                        StatusMenu.ShowMenu();
                        break;
                    case "2":
                        ItemMenu.ShowMenu();
                        break;
                    case "3":
                        OrderMenu.ShowMenu();
                        break;
                    case "0":
                        show = false;
                        break;
                    default:
                        show = false;
                        break;


                }

            }
        }

        private static void menuInfo()
        {
            System.Console.WriteLine(@"Welcome to the Trading Company!
1. Move to Status Menu.
2. Move to Item Menu.
3. Move to Order Menu.
0. Return to Main Menu;
Please choose an action: ");
        }
    }
}
