

using TradingCompany.Console.Commands;

namespace TradingCompany.Console.Menus
{
    public static class StatusMenu
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
                        StatusCommand.ShowAllStatuses();
                        break;
                    case "2":
                        StatusCommand.ShowStatus();
                        break;
                    case "3":
                        StatusCommand.AddStatus();
                        break;
                    case "4":
                        StatusCommand.UpdateStatus();
                        break;
                    case "5":
                        StatusCommand.DeleteStatus();
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
            System.Console.WriteLine(@"Status Menu.
1. Show all statuses;
2. Show a status;
3. Add a status;
4. Update a status;
5. Delete a status;
0. Return to Main Menu;
Please choose an action: ");
        }
    }
}
