using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService? EmplyeeService { get; set; }
        public IEnumerable<Employee>? Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // this is here to make it run asyncroneusly and delay is rendering by 3 seconds
            // used in conjunction with Thread.Sleep(3000) inside LoadEmployees() Method.
            //await Task.Run(LoadEmployees);
            Employees = (await EmplyeeService.GetEmployees()).ToList();
        }

        private void LoadEmployees()
        {
            Thread.Sleep(3000);
            Employee e1 = new Employee()
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "jhastings@mkportal.co.uk",
                DateOfBrith = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
               // Department = new Department { DepartmentId = 1, DepartmentName = "It" },
                DepartmentId = 1,
                PhotoPath = "images/john.png"
            };
            Employee e2 = new Employee()
            {
                EmployeeId = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "sgalloway@mkportal.co.uk",
                DateOfBrith = new DateTime(1981, 12, 22),
                Gender = Gender.Male,
                //Department = new Department { DepartmentId = 2, DepartmentName = "HR" },
                DepartmentId = 2,
                PhotoPath = "images/sam.jpg"
            };
            Employee e3 = new Employee()
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "msmith@mkportal.co.uk",
                DateOfBrith = new DateTime(1979, 11, 11),
                Gender = Gender.Female,
                //Department = new Department { DepartmentId = 1, DepartmentName = "It" },
                DepartmentId = 1,
                PhotoPath = "images/mary.png"
            };
            Employee e4 = new Employee()
            {
                EmployeeId = 4,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "slongway@mkportal.co.uk",
                DateOfBrith = new DateTime(1982, 09, 23),
                Gender = Gender.Female,
                //Department = new Department { DepartmentId = 3, DepartmentName = "Payroll" },
                DepartmentId = 4,
                PhotoPath = "images/sara.png"
            };

            Employees = new List<Employee> { e1, e2, e3, e4 };
        }
    }
}
