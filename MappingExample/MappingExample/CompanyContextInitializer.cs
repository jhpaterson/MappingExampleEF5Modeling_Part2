using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MappingExample
{
    public class CompanyContextInitializer : DropCreateDatabaseAlways<CompanyContext>
    {
        protected override void Seed(CompanyContext context)
        {
            base.Seed(context);

            #region EMPLOYEES AND ADDRESSES - SELF-REFERENCING RELATIONSHIPS AND ONE-TO-ONE
            //Address ad1 = new Address
            //{
            //    PropertyNumber = 10,
            //    Area = "G10",
            //    Property = "1XX"
            //};

            //Address ad2 = new Address
            //{
            //    PropertyNumber = 20,
            //    Area = "G20",
            //    Property = "1YY"
            //};

            //Address ad3 = new Address
            //{
            //    PropertyNumber = 30,
            //    Area = "G30",
            //    Property = "1ZZ"
            //};

            //// some Employees do not have addresses, to test 1-to-1 relationship
            //Employee emp1 = new Employee
            //{
            //    Name = "Jenson",
            //    Username = "jenson",
            //    PhoneNumber = "9876",
            //    Biography = "Jenson is a good bloke who has done a lot of stuff",
            //    Photo = new byte[100],
            //    Address = ad3
            //};

            //Employee emp2 = new Employee
            //{
            //    Name = "Checo",
            //    Username = "checo",
            //    PhoneNumber = "5432",
            //    Biography = "Checo is a new guy who has very good qualifications",
            //    Photo = new byte[100],
            //    Address = ad2,
            //    Supervisor = emp1
            //};

            //Employee emp3 = new Employee
            //{
            //    Name = "Fernando",
            //    Username = "fernando",
            //    PhoneNumber = "1234",
            //    Biography = "Fernando is very highly regarded in the industry",
            //    Photo = new byte[100],
            //    Address = ad1,
            //    Supervisor = emp1
            //};

            //Employee emp4 = new Employee
            //{
            //    Name = "Felipe",
            //    Username = "felipe",
            //    PhoneNumber = "5678",
            //    Biography = "Felipe has been with the compnay for a very long time",
            //    Photo = new byte[100],
            //    Supervisor = emp3
            //};

            //Employee emp5 = new Employee
            //{
            //    Name = "Seb",
            //    Username = "seb",
            //    PhoneNumber = "1468",
            //    Biography = "Seb is a jolly nice chap",
            //    Photo = new byte[100],
            //};

            //emp1.Buddies = new List<Employee>{
            //        emp2,
            //        emp3
            //    };

            //emp2.Buddies = new List<Employee>{
            //        emp1,
            //        emp4
            //    };

            //emp3.Buddies = new List<Employee>{
            //        emp1,
            //        emp2,
            //        emp5
            //    };

            //context.Employees.Add(emp1);
            //context.Employees.Add(emp2);
            //context.Employees.Add(emp3);
            //context.Employees.Add(emp4);
            //context.Employees.Add(emp5);
            #endregion


            #region EMPLOYEES AND DEPARTMENTS - ONE-TO-MANY
            Employee emp1 = new Employee
            {
                Name = "Jenson",
                Username = "jenson",
                PhoneNumber = "9876",
                Biography = "Jenson is a good bloke who has done a lot of stuff",
                Photo = new byte[100],
            };

            Employee emp2 = new Employee
            {
                Name = "Checo",
                Username = "checo",
                PhoneNumber = "5432",
                Biography = "Checo is a new guy who has very good qualifications",
                Photo = new byte[100]
            };

            Employee emp3 = new Employee
            {
                Name = "Fernando",
                Username = "fernando",
                PhoneNumber = "1234",
                Biography = "Fernando is very highly regarded in the industry",
                Photo = new byte[100]
            };

            Employee emp4 = new Employee
            {
                Name = "Felipe",
                Username = "felipe",
                PhoneNumber = "5678",
                Biography = "Felipe has been with the compnay for a very long time",
                Photo = new byte[100]
            };

            Employee emp5 = new Employee
            {
                Name = "Seb",
                Username = "seb",
                PhoneNumber = "1468",
                Biography = "Seb is a jolly nice chap",
                Photo = new byte[100],
            };

            Department dep1 = new Department
            {
                Name = "Marketing",
                Employees = new List<Employee>{
                    emp1,
                    emp3
                }
            };

            Department dep2 = new Department
            {
                Name = "Sales",
                Employees = new List<Employee>{
                    emp2,
                    emp4,
                    emp5
                }
            };

            context.Departments.Add(dep1);
            context.Departments.Add(dep2);
            #endregion


            #region EMPLOYEES AND PROJECTS - MANY-TO-MANY
            //Employee emp1 = new Employee
            //{
            //    Name = "Jenson",
            //    Username = "jenson",
            //    PhoneNumber = "9876",
            //    Biography = "Jenson is a good bloke who has done a lot of stuff",
            //    Photo = new byte[100],
            //};

            //Employee emp2 = new Employee
            //{
            //    Name = "Checo",
            //    Username = "checo",
            //    PhoneNumber = "5432",
            //    Biography = "Checo is a new guy who has very good qualifications",
            //    Photo = new byte[100]
            //};

            //Employee emp3 = new Employee
            //{
            //    Name = "Fernando",
            //    Username = "fernando",
            //    PhoneNumber = "1234",
            //    Biography = "Fernando is very highly regarded in the industry",
            //    Photo = new byte[100]
            //};

            //Employee emp4 = new Employee
            //{
            //    Name = "Felipe",
            //    Username = "felipe",
            //    PhoneNumber = "5678",
            //    Biography = "Felipe has been with the compnay for a very long time",
            //    Photo = new byte[100]
            //};

            //Employee emp5 = new Employee
            //{
            //    Name = "Seb",
            //    Username = "seb",
            //    PhoneNumber = "1468",
            //    Biography = "Seb is a jolly nice chap",
            //    Photo = new byte[100],
            //};

            //Project pro1 = new Project
            //{
            //    Name = "Web site",
            //};

            //Project pro2 = new Project
            //{
            //    Name = "Ad campaign",
            //};

            //pro1.AddEmployee(emp1);
            //pro1.AddEmployee(emp2);
            //pro2.AddEmployee(emp1);
            //pro2.AddEmployee(emp2);
            //pro2.AddEmployee(emp3);

            //context.Employees.Add(emp1);
            //context.Employees.Add(emp2);
            //context.Employees.Add(emp3);
            //context.Employees.Add(emp4);
            //context.Employees.Add(emp5);
            #endregion


            #region SAVING TEST OBJECTS FOR ONE-TO-ONE
            Left l1 = new Left
            {
                Name = "Alice",
            };
            Right r1 = new Right
            {
                Name = "Bob"
            };
            l1.Right = r1;
            //r1.Left = l1;

            context.Lefts.Add(l1);
            //context.Rights.Add(r1);
            #endregion

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var errors = e.EntityValidationErrors;
            }

        }
    }
}
