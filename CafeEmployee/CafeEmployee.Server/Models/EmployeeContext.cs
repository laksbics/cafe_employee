using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CafeEmployee.Server.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
              : base(options)
        {
        }

        public DbSet<Cafe> Cafes { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<EmployeeCafe> EmployeeCafe { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Cafe> cafes = new List<Cafe>();
            List<Employee> employees = new List<Employee>();
            List<EmployeeCafe> employeeCafe = new List<EmployeeCafe>();

            cafes.AddRange([ new Cafe
                        {
                            id = Guid.NewGuid(),
                            name = "Finance Team",
                            description = "Cafe for Finance Team",
                            location = "East"
                        },
                        new Cafe
                        {
                            id = Guid.NewGuid(),
                            name = "HR Team",
                            description = "Cafe for HR Team",
                            location = "West"
                        },
                        new Cafe
                        {
                            id = Guid.NewGuid(),
                            name = "DevOps Team",
                            description = "Cafe for DevOps Team",
                            location = "South"
                        },
                        new Cafe
                        {
                            id = Guid.NewGuid(),
                            name = "QA Team",
                            description = "Cafe for QA Team",
                            location = "North"
                        },
                        new Cafe
                        {
                            id = Guid.NewGuid(),
                            name = "Dev Team",
                            description = "Cafe for DEV Team",
                            location = "North East"
                        }]);

            employees.AddRange([
                    new Employee
                        {
                            id = Guid.NewGuid(),
                            name = "Lakshmanan",
                            email_address = "lakshmanan@gmail.com",
                            phone_number = "6786861",
                            gender = "Male"
                        },
                        new Employee
                        {
                            id = Guid.NewGuid(),
                            name = "Pangaraj",
                            email_address = "lakshmanan@gmail.com",
                            phone_number = "6786862",
                            gender = "Male"
                        },
                        new Employee
                        {
                            id = Guid.NewGuid(),
                            name = "Smith",
                            email_address = "Smith@gmail.com",
                            phone_number = "6786863",
                            gender = "Male"
                        },
                        new Employee
                        {
                            id = Guid.NewGuid(),
                            name = "stella",
                            email_address = "stella@gmail.com",
                            phone_number = "6786864",
                            gender = "Female"
                        },
                        new Employee
                        {
                            id = Guid.NewGuid(),
                            name = "Raja",
                            email_address = "raja@gmail.com",
                            phone_number = "6786865",
                            gender = "Male"
                        },
                        new Employee
                        {
                            id = Guid.NewGuid(),
                            name = "Rani",
                            email_address = "rani@gmail.com",
                            phone_number = "6786866",
                            gender = "Female"
                        },
                        new Employee
                        {
                            id = Guid.NewGuid(),
                            name = "Mahima",
                            email_address = "rani@gmail.com",
                            phone_number = "6786867",
                            gender = "Female"
                        },
                        new Employee
                        {
                            id = Guid.NewGuid(),
                            name = "Agnes Mary",
                            email_address = "rani@gmail.com",
                            phone_number = "6786868",
                            gender = "Female"
                        },
                        new Employee
                        {
                            id = Guid.NewGuid(),
                            name = "Arul Mahi",
                            email_address = "rani@gmail.com",
                            phone_number = "6786869",
                            gender = "Female"
                        },
                        new Employee
                        {
                            id = Guid.NewGuid(),
                            name = "Durai",
                            email_address = "durai@gmail.com",
                            phone_number = "6786860",
                            gender = "Male"
                        }]
                );

            employeeCafe.AddRange([
                    new EmployeeCafe
                        {
                            id = Guid.NewGuid(),
                            employee_id = employees[0].id,
                            cafe_id = cafes[0].id,
                            start_date = DateTime.Now.AddYears(-1),
                            end_dete = null,
                            is_active = true
                        },
                       new EmployeeCafe
                        {
                            id = Guid.NewGuid(),
                            employee_id = employees[1].id,
                            cafe_id = cafes[0].id,
                            start_date = DateTime.Now.AddYears(-1),
                            end_dete = null,
                            is_active = true
                        },
                        new EmployeeCafe
                        {
                            id = Guid.NewGuid(),
                            employee_id = employees[2].id,
                            cafe_id = cafes[1].id,
                            start_date = DateTime.Now.AddYears(-1),
                            end_dete = null,
                            is_active = true
                        },
                         new EmployeeCafe
                        {
                            id = Guid.NewGuid(),
                            employee_id = employees[3].id,
                            cafe_id = cafes[1].id,
                            start_date = DateTime.Now.AddYears(-1),
                            end_dete = null,
                            is_active = true
                        },
                         new EmployeeCafe
                        {
                            id = Guid.NewGuid(),
                            employee_id = employees[4].id,
                            cafe_id = cafes[2].id,
                            start_date = DateTime.Now.AddYears(-1),
                            end_dete = null,
                            is_active = true
                        },
                         new EmployeeCafe
                        {
                            id = Guid.NewGuid(),
                            employee_id = employees[5].id,
                            cafe_id = cafes[2].id,
                            start_date = DateTime.Now.AddYears(-1),
                            end_dete = null,
                            is_active = true
                        },
                         new EmployeeCafe
                        {
                            id = Guid.NewGuid(),
                            employee_id = employees[6].id,
                            cafe_id = cafes[3].id,
                            start_date = DateTime.Now.AddYears(-1),
                            end_dete = null,
                            is_active = true
                        },
                        new EmployeeCafe
                        {
                            id = Guid.NewGuid(),
                            employee_id = employees[7].id,
                            cafe_id = cafes[3].id,
                            start_date = DateTime.Now.AddYears(-1),
                            end_dete = null,
                            is_active = true
                        },
                         new EmployeeCafe
                        {
                            id = Guid.NewGuid(),
                            employee_id = employees[8].id,
                            cafe_id = cafes[4].id,
                            start_date = DateTime.Now.AddYears(-1),
                            end_dete = null,
                            is_active = true
                        },
                        new EmployeeCafe
                        {
                            id = Guid.NewGuid(),
                            employee_id = employees[9].id,
                            cafe_id = cafes[4].id,
                            start_date = DateTime.Now.AddYears(-1),
                            end_dete = null,
                            is_active = true
                        }]
                );

            modelBuilder.Entity<Cafe>().HasData(cafes);
            modelBuilder.Entity<Employee>().HasData(employees);
            modelBuilder.Entity<EmployeeCafe>().HasData(employeeCafe);
        }
    }
}
