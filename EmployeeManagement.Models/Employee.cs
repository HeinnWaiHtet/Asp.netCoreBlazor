using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        #region Properties

        /// <summary>
        /// Employee UniqueId
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Employee FirstName
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Employee LastName
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Employee Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Employee DateOfBrith
        /// </summary>
        public DateTime? DateOfBrith { get; set; }

        /// <summary> 
        /// Employee Gender
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Employee Department
        /// </summary>
        public Department? Department { get; set; }

        /// <summary>
        /// Employee PhotoPath
        /// </summary>
        public string? PhotoPath { get; set; }
        #endregion
    }
}
