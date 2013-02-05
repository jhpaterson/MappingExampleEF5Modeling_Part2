using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Transactions;      // need to add assembly reference
//using LinqKit;


namespace MappingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // set database initializer
            Database.SetInitializer<CompanyContext>(new CompanyContextInitializer());

            // initialise EF Profiler
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

            CompanyContext db = new CompanyContext();

            #region EMPLOYEE SELF-RELATIONSHIPS
            //var query = db.Employees
            //    .Include(e => e.Address)
            //    .Include(e => e.Supervisor)
            //    .Include(e => e.Buddies)
            //    .ToList();
            #endregion


            #region ONE-TO-ONE
            //var query = db.Employees
            //    .Include(e => e.Address)
            //    .ToList();
            //var lefts = db.Lefts
            //    .Include(l => l.Right)
            //    .ToList();
            //var rights = db.Rights
            //    .Include(r => r.Left)
            //    .ToList();
            #endregion


            #region ONE-TO-MANY
            var query = db.Departments
                .Include(d => d.Employees)
                .ToList();

            var depToDelete = db.Departments.Find(1);
            db.Departments.Remove(depToDelete);

            db.SaveChanges();

            var newQuery = db.Employees
                .ToList();
            #endregion


            #region MANY-TO-MANY JOIN TABLE
            //var query = db.Employees
            //    .Include(e => e.Projects)
            //    .ToList();
            #endregion

            #region END
            string script = ((IObjectContextAdapter)db).ObjectContext.CreateDatabaseScript();
            Console.ReadLine();
            #endregion

        }
    }
}
