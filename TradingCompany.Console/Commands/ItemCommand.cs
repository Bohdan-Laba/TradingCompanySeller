using AutoMapper;
using DAL;
using DAL.Concrete;
using DAL.Interfaces;
using TradingCompany.DTO;

namespace TradingCompany.Console.Commands
{
    public static class ItemCommand
    {
        static IMapper _mapper = setupMapper();
        static IItemDal _dal = new ItemDal(_mapper);

        private static IMapper setupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(ItemDal).Assembly)
                );
            return config.CreateMapper();
        }

        public static void AddItem()
        {
            System.Console.Write("Enter an item name: ");
            string _name = System.Console.ReadLine();
            System.Console.Write("Enter an item price: ");
            int _price = int.Parse(System.Console.ReadLine());
            System.Console.Write("Enter a SellerID of this item: ");
            int _seller = int.Parse(System.Console.ReadLine());

            var newItem = new ItemDto
            {
                Name = _name,
                Price = _price,
                SellerID = _seller, //todo get a seller ID from UserRole
            };

            newItem = _dal.CreateItem(newItem);
            var temp = newItem.Availability ? "Available" : "Unavailable";

            System.Console.WriteLine($"Item created!\nItemID:{newItem.ItemID}; Name:{newItem.Name}; Price:{newItem.Price}; Seller:{newItem.SellerID}; {temp} \n");

            System.Console.WriteLine($"Item added! ID:{newItem.ItemID}");
        }

        public static void ShowAllItems()
        {
            var items = _dal.GetAllItems();

            foreach (var item in items)
            {
                var temp = item.Availability ? "Available" : "Unavailable";
                System.Console.WriteLine($"Item ID:{item.ItemID}; Name:{item.Name}; Price:{item.Price}; Seller:{item.SellerID}; {temp} \n");
            }

        }

        public static void ShowItem()
        {
            System.Console.Write("Enter a Item id: ");
            int id = int.Parse(System.Console.ReadLine());
            var item = _dal.GetItem(id);

            var temp = item.Availability ? "Available" : "Unavailable";
            System.Console.WriteLine($"Item found!\nItem ID:{item.ItemID}; Name:{item.Name}; Price:{item.Price}; Seller:{item.SellerID}; {temp} \n");
        }

        public static void UpdateItem()
        {
            System.Console.Write("Enter a Item id: ");
            int _id = int.Parse(System.Console.ReadLine());

            var thisItem = _dal.GetItem(_id);
            System.Console.WriteLine();
            System.Console.WriteLine("Leave an empty field if you do not want to change the row");
            System.Console.WriteLine();

            System.Console.Write("Enter an item name: ");
            string nameStr = System.Console.ReadLine();
            string _name = string.IsNullOrWhiteSpace(nameStr) ? thisItem.Name : nameStr;

            System.Console.Write("Enter an item price: ");
            var priceStr = System.Console.ReadLine();
            double _price = string.IsNullOrWhiteSpace(priceStr) ? thisItem.Price : int.Parse(priceStr);

            System.Console.Write("Enter a SellerID of this item: ");
            string sellerStr = System.Console.ReadLine();
            int _seller = string.IsNullOrWhiteSpace(sellerStr) ? thisItem.SellerID : int.Parse(sellerStr);

            System.Console.Write("Enter availability of this item: ");
            string avabStr = System.Console.ReadLine();
            bool _availability = string.IsNullOrWhiteSpace(avabStr) ? thisItem.Availability : bool.Parse(avabStr);

            var newItem = new ItemDto
            {
                ItemID = _id,
                Name = _name,
                Price = _price,
                SellerID = _seller, //todo get a seller ID from UserRole
                Availability = _availability,
            };

            _dal.UpdateItem(newItem);

            var temp = newItem.Availability ? "Available" : "Unavailable";
            System.Console.WriteLine($"Item updated!\nItem ID:{newItem.ItemID}; Name:{newItem.Name}; Price:{newItem.Price}; Seller:{newItem.SellerID}; {temp} \n");
        }
        public static void DeleteItem()
        {
            System.Console.Write("Enter a status id: ");
            int id = int.Parse(System.Console.ReadLine());
            _dal.DeleteItem(id);
            System.Console.WriteLine("Item deleted successfully!");
        }

    }
}
