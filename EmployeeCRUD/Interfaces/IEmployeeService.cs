using EmployeeCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        void Add(Employee employee);
        Employee GetById(int id);
        void Update(int id, Employee employee);
        void Remove(int id);
    }
}
