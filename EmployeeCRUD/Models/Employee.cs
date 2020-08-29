using EmployeeCRUD.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public string Skillsets { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public bool? IsActive { get; set; }
    }
}
