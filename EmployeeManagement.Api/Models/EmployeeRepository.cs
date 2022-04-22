using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Properties

        private readonly AppDbContext dbContext;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor Injection
        /// </summary>
        /// <param name="dbContext"></param>
        public EmployeeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region PublicMethods

        /// <summary>
        /// Add EmployeeData by request value
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Employee> AddEmployee(Employee employee)
        {
            /** Add Employee Data To Dabase */
            var result = await this.dbContext.Employees.AddAsync(employee);
            /** Save Employee Data To Dabase */
            this.dbContext.SaveChanges();
            /** Return Created Employee Information */
            return result.Entity;
        }

        /// <summary>
        /// Delete Employee Data By Request Id
        /// </summary>
        /// <param name="employeeId"></param>
        public async Task<Employee?> DeleteEmployee(int employeeId)
        {
            /** Get Employee Data By Request Employee Id */
            var result = await this.dbContext.Employees.FirstOrDefaultAsync(
                emp =>emp.EmployeeId == employeeId);

            /** Check Find Employee Has or not and delete */
            if (result != null)
            {
                this.dbContext.Employees.Remove(result);
                this.dbContext.SaveChanges();
                return result;
            }

            return null;
        }

        /// <summary>
        /// Get Employee Information By Request EmployeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Employee?> GetEmployee(int employeeId) =>
            await this.dbContext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == employeeId);

        /// <summary>
        /// Get Employee Data By Request Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Employee?> GetEmployeeByEmail(string email) =>
            await this.dbContext.Employees.FirstOrDefaultAsync(emp => emp.Email == email) ?? null;

        /// <summary>
        /// Get All Employee Data
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployees() =>
            await this.dbContext.Employees.ToListAsync();

        public async Task<Employee?> UpdateEmployee(Employee employee)
        {
            /** Get Employee Data By Request Employee Id */
            var result = await this.dbContext.Employees.FirstOrDefaultAsync(
                emp => emp.EmployeeId == employee.EmployeeId);

            /** Update Employee Data By Request Employee Data */
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBrith = employee.DateOfBrith;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await this.dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
        #endregion
    }
}
