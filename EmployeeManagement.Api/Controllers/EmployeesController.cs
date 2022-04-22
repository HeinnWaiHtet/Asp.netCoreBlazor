using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        #region Properties

        private readonly IEmployeeRepository employeeRepository;
        #endregion

        #region
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        #endregion

        #region GetAllEmployee

        /// <summary>
        /// Get Employee Data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                /** Return Employee Data From Database */
                return this.Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error Reteriving Data From Database");
            }
        }
        #endregion

        #region GetEmployeeById

        /// <summary>
        /// Get Employee Data by request id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                /** Get Employee By Request Id */
                var result = await employeeRepository.GetEmployee(id);

                /** when request Id employee not found return not found not yet return employee */
                return result == null ? NotFound() : result;
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error Reteriving Data From Database");
            }
        }
        #endregion

        #region CreateEmployee

        /// <summary>
        /// Add Employee By Request Employee Data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                /** Check request Employee */
                if (employee == null)
                {
                    /** Return badrequest when request data invalid */
                    return this.BadRequest();
                }

                /** Find Employee by Email */
                var result = await this.employeeRepository.GetEmployeeByEmail(employee.Email ?? string.Empty);

                /** Check Employee request Email is in use or not */
                if (result != null)
                {
                    ModelState.AddModelError("Email", "This email is already taken by other user");
                    return this.BadRequest(ModelState);
                }

                /** Add Employee */
                var createdEmployee = await this.employeeRepository.AddEmployee(employee);

                /** Return Created Employee with new link, created Id, created Data */
                return this.CreatedAtAction(
                    nameof(CreateEmployee),
                    new { id = createdEmployee.EmployeeId },
                    createdEmployee);
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error Reteriving Data From Database");
            }
        }
        #endregion

        #region UpdateEmployee

        /// <summary>
        /// Update Employee Data By Request Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee?>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                /** Check Request Employee Id match or not */
                if (id != employee.EmployeeId)
                {
                    /** */
                    return this.BadRequest("Employee Id MisMatch");
                }

                /** Get Employee Data by request Id */
                var result = await this.employeeRepository.GetEmployee(employee.EmployeeId);

                if (result == null)
                {
                    return this.NotFound($"Employee with request Id {employee.EmployeeId} not found");
                }

                /** Return Employee With Updated Data */
                return await this.employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status400BadRequest,
                    "Error Updating Data");
            }
        }
        #endregion

        #region DeleteEmployee

        /// <summary>
        /// Delete Employee By Request Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee?>> DeleteEmployee(int id)
        {
            try
            {
                /** Get Employee By Id */
                var result = await this.employeeRepository.GetEmployee(id);

                if (result == null)
                {
                    return this.NotFound($"Employee with Id = {id} not found");
                }

                /** Reurn Deleted Employee*/
                return await this.employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error Deleting Employee Data");
            }
        }
        #endregion

        #region
        #endregion
    }
}
