using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Models
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetEmployees();

        /// <summary>
        /// Get Employee Data by request Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<Employee?> GetEmployee(int employeeId);

        /// <summary>
        /// Get Employee Data by request email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Employee?> GetEmployeeByEmail(string email);

        /// <summary>
        /// add employee Data by request Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task<Employee> AddEmployee(Employee employee);

        /// <summary>
        /// Update Employee Data by request Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task<Employee?> UpdateEmployee(Employee employee);

        /// <summary>
        /// Delete Employee By Request Id
        /// </summary>
        /// <param name="employeeId"></param>
        Task<Employee?> DeleteEmployee(int employeeId);
    }
}
