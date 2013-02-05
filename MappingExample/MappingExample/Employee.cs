using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MappingExample
{
    public class Employee
    {
        protected const string EMAIL_SUFFIX = "@example.com";

        public Employee()
        {
            this.Projects = new List<Project>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Biography { get; set; }
        public byte[] Photo { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }

        #region SELF-REFERENCING RELATIONSHIPS
        public Employee Supervisor { get; set; }
        public List<Employee> Buddies { get; set; }
        #endregion

        #region MANY-TO-MANY JOIN
        public List<Project> Projects { get; set; }
        #endregion

        [NotMapped]
        public virtual string Email
        {
            get
            {
                return Username + EMAIL_SUFFIX;
            }
        }

    }
}
