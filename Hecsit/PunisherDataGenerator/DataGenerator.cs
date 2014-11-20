using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Punisher.Domain;

namespace PunisherDataGenerator
{
    public class DataGenerator
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeAction> _employeeActionRepository;
        private readonly IRepository<ActionType> _actionTypeRepository;
        private readonly IRepository<MeasureType> _measureTypeRepository;
/*        ^ ^
         (>_<) ♥♥♥
         •(♥)•
          • • 
*/
        private readonly IRepository<Measure> _measureRepository;

        public DataGenerator(IRepository<Employee> employeeRepository, IRepository<EmployeeAction> employeeActionRepository, IRepository<ActionType> actionTypeRepository, IRepository<MeasureType> measureTypeRepository, IRepository<Measure> measureRepository)
        {
            if (employeeRepository == null) throw new ArgumentNullException("employeeRepository");
            if (employeeActionRepository == null) throw new ArgumentNullException("employeeActionRepository");
            if (actionTypeRepository == null) throw new ArgumentNullException("actionTypeRepository");
            if (measureTypeRepository == null) throw new ArgumentNullException("measureTypeRepository");
            if (measureRepository == null) throw new ArgumentNullException("measureRepository");

            _employeeRepository = employeeRepository;
            _employeeActionRepository = employeeActionRepository;
            _actionTypeRepository = actionTypeRepository;
            _measureTypeRepository = measureTypeRepository;
            _measureRepository = measureRepository;
        }

        public void GenerateAll()
        {
            GenerateEmployee();
            GenerateEmployeeActions();
            GenerateMeasure();
        }

        /*private void GenerateRoomTypes()
        {
            _roomTypesRepository.Add(new RoomType("Single Standard Room", 40.0m));
            _roomTypesRepository.Add(new RoomType("Single Superior Room", 70));
            _roomTypesRepository.Add(new RoomType("Double Superior Room", 130.0m));
            _roomTypesRepository.Add(new RoomType("Studio Room", 120));
            _roomTypesRepository.Add(new RoomType("De Luxe Room", 250.0m));
            _roomTypesRepository.Add(new RoomType("De Luxe Grande Suite", 400.0m));
        }*/
        private void GenerateEmployee()
        {
            _roomTypesRepository.Add(new RoomType("Single Standard Room", 40.0m));
            _roomTypesRepository.Add(new RoomType("Single Superior Room", 70));
            _roomTypesRepository.Add(new RoomType("Double Superior Room", 130.0m));
            _roomTypesRepository.Add(new RoomType("Studio Room", 120));
            _roomTypesRepository.Add(new RoomType("De Luxe Room", 250.0m));
            _roomTypesRepository.Add(new RoomType("De Luxe Grande Suite", 400.0m));
        }

       /* private void GenerateRooms()
        {
            var singleStandartRoom = _roomTypesRepository.FindByName("Single Standard Room");
            var singleSuperiorRoom = _roomTypesRepository.FindByName("Single Superior Room");
            var doubleSuperiorRoom = _roomTypesRepository.FindByName("Double Superior Room");
            var studioRoom = _roomTypesRepository.FindByName("Studio Room");
            var deLuxeRoom = _roomTypesRepository.FindByName("De Luxe Grande Suite");
            var deLuxeGrandeSuite = _roomTypesRepository.FindByName("De Luxe Grande Suite");

            _roomsRepository.Add(new Room("101", RoomStatus.Free, singleStandartRoom));
            _roomsRepository.Add(new Room("102", RoomStatus.Free, singleStandartRoom));
            _roomsRepository.Add(new Room("103", RoomStatus.Free, singleStandartRoom));
            _roomsRepository.Add(new Room("104", RoomStatus.Free, singleSuperiorRoom));
            _roomsRepository.Add(new Room("105", RoomStatus.Free, singleSuperiorRoom));
            _roomsRepository.Add(new Room("106", RoomStatus.Free, doubleSuperiorRoom));
            _roomsRepository.Add(new Room("107", RoomStatus.Free, doubleSuperiorRoom));
            _roomsRepository.Add(new Room("201", RoomStatus.Free, studioRoom));
            _roomsRepository.Add(new Room("202", RoomStatus.Free, deLuxeRoom));
            _roomsRepository.Add(new Room("203", RoomStatus.Free, deLuxeRoom));
            _roomsRepository.Add(new Room("301", RoomStatus.Free, deLuxeGrandeSuite));
            _roomsRepository.Add(new Room("401", RoomStatus.Free, deLuxeGrandeSuite));
        }

        private void GenerateServiceTypes()
        {
            _serviceTypesRepository.Add(new ServiceType("Billiard", 10.0m, ServiceBillingType.Hourly));
            _serviceTypesRepository.Add(new ServiceType("Bowling", 20.0m, ServiceBillingType.Hourly));
            _serviceTypesRepository.Add(new ServiceType("Mini Bar", 20.0m, ServiceBillingType.Daily));
            _serviceTypesRepository.Add(new ServiceType("Massage", 30.0m, ServiceBillingType.FixedPrice));
            _serviceTypesRepository.Add(new ServiceType("Sauna", 40.0m, ServiceBillingType.Hourly));
            _serviceTypesRepository.Add(new ServiceType("Golf", 100.0m, ServiceBillingType.Hourly));
        }

        private void GenerateVisit()
        {
            var client = new Client("John Smith", "910-900-50-45");
            var visit = new Visit(DateTime.Today, client);

            var weekAgo = DateTime.Now.Subtract(TimeSpan.FromDays(7));
            var twoWeeksAgo = DateTime.Now.Subtract(TimeSpan.FromDays(14));
            var roomBooking = new RoomBooking(twoWeeksAgo, weekAgo, _roomsRepository.AsQueryable().ElementAt<Room>(0), visit);
            var anotherRoomBooking = new RoomBooking(weekAgo, DateTime.MaxValue, _roomsRepository.AsQueryable().ElementAt<Room>(11), visit);
            _roomsRepository.AsQueryable().ElementAt<Room>(11).Status = RoomStatus.Occupied;

            var dayAgo = DateTime.Today.Subtract(TimeSpan.FromHours(24));
            var hourAgo = DateTime.Today.Subtract(TimeSpan.FromHours(1));
            var service = new Service(dayAgo, hourAgo, _serviceTypesRepository.AsQueryable().ElementAt<ServiceType>(5), visit);
            var anotherService = new Service(dayAgo, DateTime.MaxValue, _serviceTypesRepository.AsQueryable().ElementAt<ServiceType>(2), visit);

            _clientsRepository.Add(client);
            _visitsRepository.Add(visit);
            _roomBookingsRepository.Add(roomBooking);
            _roomBookingsRepository.Add(anotherRoomBooking);
            _servicesRepository.Add(service);
            _servicesRepository.Add(anotherService);
        }*/
    }
}
