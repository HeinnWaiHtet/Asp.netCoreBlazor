using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.ComponentModel
{
    public class EmployeeDetailsBase : ComponentBase
    {
        #region Properties

        public Employee employee { get; set; } = new Employee();

        /** Injection Container For API Request */
        [Inject]
        public IEmployeeService employeeService { get; set; }

        [Parameter]
        public string? Id { get; set; }
        #endregion

        #region ProtectedMethods

        /// <summary>
        /// Initialize Async Method
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            this.Id = this.Id ?? "1";
            employee = await this.employeeService.GetEmployeeById(int.Parse(this.Id)) ?? new Employee();
        }
        #endregion

        #region PrivateMethods
        #endregion
    }
}
