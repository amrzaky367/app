using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id = 1 , Name = "AMR" , Email = "amr@admin" , Department =Dept.HR},
                new Employee(){Id = 2 , Name = "test" , Email = "test@admin" , Department =Dept.IT},
                new Employee(){Id = 3 , Name = "mo" , Email = "mo@admin" , Department = Dept.Payroll}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        Employee IEmployeeRepository.GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        IEnumerable<Employee> IEmployeeRepository.GetEmployees()
        {
            return _employeeList;
        }

        public Employee Update(Employee employeeChanged)
        {
           
            return employeeChanged;

        }

        public Employee Delete(int Id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
            return employee;
        }
    }
}
