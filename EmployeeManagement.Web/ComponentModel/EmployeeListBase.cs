using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.ComponentModel
{
    public class EmployeeListBase : ComponentBase
    {
        #region Properties

        public IEnumerable<Employee>? Employees { get; set; }

        /** Injection for Employee Service */
        [Inject]
        public IEmployeeService employeeService { get; set; }
        #endregion

        #region ProtectedMethods

        /// <summary>
        /// Initialize Async Method For Initialization Data
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            /** Get Employee Data From API */
            this.Employees = (await this.employeeService.GetEmployees())?.ToList();
        }
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Initialize Custom Employee Data
        /// </summary>
        private void LoadEmployees()
        {
            /** Create Threads For Async Process */
            Thread.Sleep(8000);
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "David@pragimtech.com",
                DateOfBrith = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/john.png"
            };

            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "Sam@pragimtech.com",
                DateOfBrith = new DateTime(1981, 12, 22),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/sam.jpg"
            };

            Employee e3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@pragimtech.com",
                DateOfBrith = new DateTime(1979, 11, 11),
                Gender = Gender.Female,
                DepartmentId = 2,
                PhotoPath = "images/mary.png"
            };

            Employee e4 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@pragimtech.com",
                DateOfBrith = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                DepartmentId = 3,
                PhotoPath = "images/sara.png"
            };

            Employees = new List<Employee> { e1, e2, e3, e4 };
        }
        #endregion
    }
}
