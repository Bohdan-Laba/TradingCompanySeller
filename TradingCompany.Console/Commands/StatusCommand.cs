using AutoMapper;
using DAL.Concrete;
using DAL.Interfaces;
using System.Runtime.CompilerServices;
using TradingCompany.DTO;

namespace TradingCompany.Console.Commands
{
    public static class StatusCommand
    {
        static IMapper _mapper = setupMapper();
        static IStatusDal _dal = new StatusDal(_mapper);

        private static IMapper setupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(StatusDal).Assembly)
                );
            return config.CreateMapper();
        }

        public static void AddStatus()
        {
            System.Console.Write("Enter a status name: ");
            string _name = System.Console.ReadLine();

            var newItem = new StatusDto {
                Name = _name,
                };

            newItem = _dal.CreateStatus(newItem);

            System.Console.WriteLine($"Status added! ID:{newItem.StatusID}");
        }

        public static void ShowAllStatuses()
        {
            var statuses = _dal.GetAllStatuses();

            foreach (var item in statuses)
            {
                System.Console.WriteLine($"ID:{item.StatusID}\t Status Name:{item.Name}\n");
            }

        }

        public static void ShowStatus()
        {
            System.Console.Write("Enter a status id: ");
            int id = int.Parse(System.Console.ReadLine());
            var item = _dal.GetStatus(id);

            System.Console.WriteLine($"ID:{item.StatusID}\t Status Name:{item.Name}\n");
        }

        public static void UpdateStatus()
        {
            System.Console.Write("Enter a status id: ");
            int _id = int.Parse(System.Console.ReadLine());
            System.Console.Write("Enter a new status name: ");
            string _name = System.Console.ReadLine();

            var newItem = new StatusDto
            {
                StatusID = _id,
                Name = _name,
            };

            _dal.UpdateStatus(newItem);

            System.Console.WriteLine($"Status updated! ID:{newItem.StatusID}");
        }

        public static void DeleteStatus()
        {
            System.Console.Write("Enter a status id: ");
            int id = int.Parse(System.Console.ReadLine());

            _dal.DeleteStatus(id);
            System.Console.WriteLine("Item deleted successfully!");

        }
    }
}
