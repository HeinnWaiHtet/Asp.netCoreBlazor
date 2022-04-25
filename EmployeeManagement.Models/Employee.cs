using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Employee LastName
        /// </summary>
        [Required]
        public string? LastName { get; set; }

        /// <summary>
        /// Employee Email
        /// </summary>
        [Required]
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
        public int DepartmentId { get; set; }

        /// <summary>
        /// Deparment For Join Employee
        /// </summary>
        public Department? Department { get; set; }

        /// <summary>
        /// Employee PhotoPath
        /// </summary>
        public string? PhotoPath { get; set; }
        #endregion
    }
}
