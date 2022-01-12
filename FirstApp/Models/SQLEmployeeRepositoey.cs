using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Models
{
    public class SQLEmployeeRepositoey : IEmployeeRepository
    {
        private AppDbContext _appDbContext;

        public SQLEmployeeRepositoey(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Employee Add(Employee employee)
        {
             _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _appDbContext.Employees.Find(Id);
            if(employee != null)
            {
                _appDbContext.Employees.Remove(employee);
                _appDbContext.SaveChanges();
            }

            return employee; 
        }

        public Employee GetEmployee(int id)
        {
            return _appDbContext.Employees.Find(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _appDbContext.Employees;
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = _appDbContext.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.SaveChanges();
            return employeeChanges;
        }
    }
}
