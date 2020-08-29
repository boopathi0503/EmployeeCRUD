using EmployeeCRUD.Interfaces;
using EmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.BusinessServices
{
    public class EmployeeService: IEmployeeService
    {
        private readonly EmployeeDBContext _context;
        public EmployeeService(EmployeeDBContext context)
        {
            _context = context;
        }
        IEnumerable<Employee> IEmployeeService.GetAllEmployees()
        {
            return  _context.Employees.ToList();
        }
        void IEmployeeService.Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        Employee IEmployeeService.GetById(int id)
        {
            var employee = _context.Employees.Find(id);            
            return employee;
        }
        void IEmployeeService.Update(int id, Employee employee)
        {
            var emp = _context.Employees.Find(id);
            if (emp != null)
                _context.Entry(employee).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }

            
        }
        void IEmployeeService.Remove(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }
    }
}
