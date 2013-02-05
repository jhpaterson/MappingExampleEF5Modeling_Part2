using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace MappingExample
{
    public class CompanyContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // FOR TESTING ONE-TO-ONE
        public DbSet<Left> Lefts { get; set; }
        public DbSet<Right> Rights { get; set; }

        public CompanyContext()
            : base()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region SELF REFERENCING MANY-TO-MANY
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Buddies)
                .WithMany()
                .Map(mc =>
                {
                    mc.MapLeftKey("LeftEmployeeId");
                    mc.MapRightKey("RightEmployeeId");
                    mc.ToTable("Buddieships");
                });
            #endregion


            #region SHARED PK ONE-TO-ONE
            // RELATIONSHIP FOR DOMAIN OBJECTS
            // this allows Employee without Address
            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.Address)
                .WithRequired();

            // these doesn't allow Employee without Address (compare with tests below)
            //modelBuilder.Entity<Employee>()
            //    .HasRequired(e => e.Address)
            //    .WithOptional();
            // OR this, but in this particular scenario EF can't work out which is the principal 
            //modelBuilder.Entity<Address>()
            //    .HasRequired(a => a.Employee)
            //    .WithRequiredPrincipal(e => e.Address);




            // TEST WITH TWO SYMMETRIC CLASSES
            // chooses Left PK as identity, FK in Right, can save orphaned Left, can save Right with Left
            //modelBuilder.Entity<Left>()
            //    .HasOptional(c => c.Right)
            //    .WithRequired();

            // chooses Right PK as identity, FK in Left, can save orphaned Right, can save Left with Right
            //modelBuilder.Entity<Right>()
            //    .HasOptional(c => c.Left)
            //    .WithRequired();

            // chooses Right PK as identity, FK in Right, saves Left with Right, doesn't save Right with Left, 
            // doesn't save orphaned Left
            //modelBuilder.Entity<Left>()
            //    .HasRequired(c => c.Right)
            //    .WithOptional();

            // chooses Left PK as identity, FK in Left, saves Right with Left, doesn't save Left with Right
            //modelBuilder.Entity<Right>()
            //    .HasRequired(c => c.Left)
            //    .WithOptional();

            // chooses Left PK as identity, uses PK as FK field in Right, can save Right with Left, Left with Right, 
            // orphaned left but not orphaned right
            //modelBuilder.Entity<Left>()
            //    .HasRequired(c => c.Right)
            //    .WithRequiredPrincipal(c => c.Left);

            // chooses Right PK as identity, uses PK as FK field in Right, can save Left with Riight, Right with Left
            // orphaned Right, but not orphaned Left
            modelBuilder.Entity<Right>()
                .HasRequired(c => c.Left)
                .WithRequiredPrincipal(c => c.Right);
            #endregion


            #region ONE-TO-MANY
            // this works without inverse navigation property or FK property in Employee
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithRequired()
                .Map(m => m.MapKey("DepartmentCode"))
                .WillCascadeOnDelete();
            #endregion


            #region MANY-TO-MANY
            //modelBuilder.Entity<Employee>()
            //    .HasMany(e => e.Projects)
            //    .WithMany(p => p.Employees)
            //    .Map(m =>
            //    {
            //        m.ToTable("Assignments");
            //        m.MapLeftKey("Employee");
            //        m.MapRightKey("Project");
            //    });
            #endregion
        }
    }
}
