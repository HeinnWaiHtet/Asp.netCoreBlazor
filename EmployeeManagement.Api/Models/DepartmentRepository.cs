using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        #region Properties

        private readonly AppDbContext dbContext;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor Injection
        /// </summary>
        /// <param name="dbContext"></param>
        public DepartmentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion


        #region Public Methods

        /// <summary>
        /// Get Department By Request Id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public Department? GetDepartment(int departmentId) =>
            this.dbContext.Departments.FirstOrDefault(dpt => dpt.DepartmentId == departmentId);

        /// <summary>
        /// Get All Department
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Department> GetDepartments() => this.dbContext.Departments;
        #endregion
    }
}
