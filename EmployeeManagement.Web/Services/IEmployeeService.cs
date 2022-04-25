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

        /// <summary>
        /// Get Employee Data By Request Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Employee?> GetEmployeeById(int id);
    }
}
