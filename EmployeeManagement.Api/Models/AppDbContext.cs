using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class AppDbContext : DbContext
    {
        #region Properties

        /** Database table name with Employees */
        public DbSet<Employee> Employees { get; set; }
        /** Database table name with Departments */
        public DbSet<Department> Departments { get; set; }
        #endregion

        #region Constructor

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        #endregion

        #region ProtectedMethods

        /// <summary>
        /// Model Creating Default Assign Method
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
        #endregion

        #region PrivateMethods

        #endregion
    }
}
