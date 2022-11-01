

using TradingCompany.Console.Commands;

namespace TradingCompany.Console.Menus
{
    public static class OrderMenu
    {

        public static void ShowMenu()
        {
            bool show = true;
            while (show)
            {
                //Console.Clear();
                menuInfo();
                string input = System.Console.ReadLine();
                switch (input)
                {
                    case "1":

                        break;


                }
            }

        }
        private static void menuInfo()
        {
            System.Console.WriteLine(@"Order Menu.
1. Show all orders;
2. Show an order;
3. Add an order;
4. Delete an order;
0. Return to Main Menu;
Please choose an action: ");
        }
    }
}
