using EmployeeCRUD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeCRUDTest
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(EmployeeDBContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Employees.AddRange(
                new Employee() 
                { 
                    Name = "Emp1", 
                    Address = "Address1", 
                    Role = "Tech Lead", 
                    Department = "IT Services", 
                    Skillsets = "C#, Dot net, Web Api, Angular", 
                    DateOfBirth = new DateTime(1986, 4, 3), 
                    DateOfJoining = new DateTime(2011, 1, 28), 
                    IsActive = true 
                },
                new Employee()
                {
                    Name = "Emp2",
                    Address = "Address2",
                    Role = "Tech Lead",
                    Department = "IT Services",
                    Skillsets = "C#, Dot net, Web Api",
                    DateOfBirth = new DateTime(1990, 5, 23),
                    DateOfJoining = new DateTime(2010, 5, 17),
                    IsActive = true
                }, new Employee()
                {
                    Name = "Emp3",
                    Address = "Address3",
                    Role = "Tech Lead",
                    Department = "IT Services",
                    Skillsets = "C#, Dot net, Angular",
                    DateOfBirth = new DateTime(1987, 11, 17),
                    DateOfJoining = new DateTime(2010, 12, 24),
                    IsActive = true
                },
                new Employee()
                {
                    Name = "Emp4",
                    Address = "Address4",
                    Role = "Senior Analyst",
                    Department = "IT Services",
                    Skillsets = "C#, Dot net, WPF",
                    DateOfBirth = new DateTime(1988, 8, 6),
                    DateOfJoining = new DateTime(2012, 2, 6),
                    IsActive = true
                },
                new Employee()
                {
                    Name = "Emp5",
                    Address = "Address5",
                    Role = "SSE",
                    Department = "IT Services",
                    Skillsets = "C#, Dot net, WCF",
                    DateOfBirth = new DateTime(1986, 9, 10),
                    DateOfJoining = new DateTime(2011, 8, 8),
                    IsActive = true
                }

                );
            context.SaveChanges();
        }
    }
}
