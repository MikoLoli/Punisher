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
        private readonly IRepository<Measure> _measureRepository;
/*        ^ ^
         (>_<) ♥♥♥
         •(♥)•
          • • 
*/
        public DataGenerator(IRepository<Employee> employeeRepository, IRepository<EmployeeAction> employeeActionRepository, 
            IRepository<ActionType> actionTypeRepository, IRepository<MeasureType> measureTypeRepository,
            IRepository<Measure> measureRepository)
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
           // GenerateMeasure();
        }

        private void GenerateEmployee()
        {
            _employeeRepository.Add(new Employee("Nolan Ross", "001", DateTime.Parse("2/16/2008 11:15:12 AM"),
                 3, "DG", 1.0m, 1000000.0m));
            _employeeRepository.Add(new Employee("Aiden Mathis", "002", DateTime.Parse("5/10/2011 10:25:54 AM"),
                1, "Financial analyst", 1.0m, 50000.0m));
            _employeeRepository.Add(new Employee("Mason Treadwell", "003", DateTime.Parse("7/7/2010 09:20:13 AM"),
                0, "Redactor", 1.0m, 40000.0m));
            _employeeRepository.Add(new Employee("David Clarke", "004", DateTime.Parse("3/14/2009 1:40:28 PM"),
                2, "Team lead", 1.0m, 80000.0m));
            _employeeRepository.Add(new Employee("Padma Lahare", "005", DateTime.Parse("8/5/2014 09:57:23 AM"),
                1, "Junior developer", 1.0m, 30000.0m));
        }

        private void GenerateEmployeeActions()
        {
           
        }
        
    }
}
