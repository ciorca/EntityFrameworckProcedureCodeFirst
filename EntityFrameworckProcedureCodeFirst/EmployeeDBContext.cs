using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EntityFrameworckProcedureCodeFirst 
{
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().MapToStoredProcedures
                (p => p.Insert(i => i.HasName("InsertEmployee")
                               .Parameter(n => n.Name, "EmployeeName")
                               .Parameter(n => n.Gender, "EmployeeGender")
                               .Parameter(n => n.Salary, "EmployeeSalary"))
                       .Update(u => u.HasName("UnpdateEmployee")
                                .Parameter(n => n.ID, "EmployeeID")
                               .Parameter(n => n.Name, "EmployeeName")
                              .Parameter(n => n.Gender, "EmployeeGender")
                              .Parameter(n => n.Salary, "EmployeeSalary"))
                       .Delete(d => d.HasName("DeleteEmployee")
                                .Parameter(n => n.ID, "EmployeeID"))

                );

            base.OnModelCreating(modelBuilder);
        }
    }
}