using System.Collections.Generic;

namespace MappingExample
{
    public class Project
    {
                public Project()
        {
            this.Employees = new List<Employee>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

        public void AddEmployee(Employee emp)
        {
            Employees.Add(emp);
            emp.Projects.Add(this);
        }



    }
}
