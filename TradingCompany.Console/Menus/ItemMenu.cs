

using TradingCompany.Console.Commands;

namespace TradingCompany.Console.Menus
{
    public static class ItemMenu
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
                        ItemCommand.ShowAllItems();
                        break;
                    case "2":
                        ItemCommand.ShowItem();
                        break;
                    case "3":
                        ItemCommand.AddItem();
                        break;
                    case "4":
                        ItemCommand.UpdateItem();
                        break;
                    case "5":
                        ItemCommand.DeleteItem();
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
            System.Console.WriteLine(@"Item Menu.
1. Show all items;
2. Show an item;
3. Add an item;
4. Update an item;
5. Delete an item;
0. Return to Main Menu;
Please choose an action: ");
        }
    }
}
