using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        #region Properties

        private readonly HttpClient httpClient;
        #endregion

        #region Constructor

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        #endregion

        #region PublicMethods

        /// <summary>
        /// Get All Employee Data From api
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>?> GetEmployees()
        {
            return await this.httpClient.GetFromJsonAsync<Employee[]?>("api/employees");
        }

        /// <summary>
        /// Get Employee Data By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await this.httpClient.GetFromJsonAsync<Employee?>($"api/employees/{id}");
        }

        #endregion
    }
}
