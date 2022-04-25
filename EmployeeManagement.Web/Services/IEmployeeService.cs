using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Get All Employee Lists
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Employee>?> GetEmployees();
    }
}
