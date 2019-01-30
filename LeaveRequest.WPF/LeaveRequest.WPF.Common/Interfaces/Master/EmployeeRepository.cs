using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;

namespace LeaveRequest.WPF.Common.Interfaces.Master
{
    public class EmployeeRepository : IEmployeeRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        public bool Delete(int? id)
        {
            var result = 0;
            Employee employee = Get(id);

            employee.IsDelete = true;
            employee.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Employee> Get()
        {
            var get = _context.Employees.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Employee Get(int? id)
        {
            
            var get = _context.Employees.Find(id);
            return get;
        }

        public bool Insert(EmployeeParam employeeParam)
        {
            var result = 0;
            Employee employee = new Employee();

            employee.Name = employeeParam.Name;
            employee.Gender = employeeParam.Gender;
            employee.Marriage = employeeParam.Marriage;
            employee.Children_Total = employeeParam.Children_Total;
            employee.Username = employeeParam.Username;
            employee.Password = employeeParam.Password;
            employee.Last_Year = employeeParam.Last_Year;
            employee.This_Year = employeeParam.This_Year;
            employee.Manager_Id = employeeParam.Manager_Id;
            employee.Religion = employeeParam.Religion;
            employee.Division_Id = employeeParam.Division_Id;
            employee.Position_Id = employeeParam.Position_Id;
            employee.JoinDate = DateTimeOffset.Now.LocalDateTime;
            employee.CreateDate = DateTimeOffset.Now.LocalDateTime;

            _context.Employees.Add(employee);
            result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int? id, EmployeeParam employeeParam)
        {
            var result = 0;
            Employee employee = Get(id);

            employee.Name = employeeParam.Name;
            employee.Gender = employeeParam.Gender;
            employee.Marriage = employeeParam.Marriage;
            employee.Children_Total = employeeParam.Children_Total;
            employee.Username = employeeParam.Username;
            employee.Password = employeeParam.Password;
            employee.Last_Year = employeeParam.Last_Year;
            employee.This_Year = employeeParam.This_Year;
            employee.Manager_Id = employeeParam.Manager_Id;
            employee.Religion = employeeParam.Religion;
            employee.Division_Id = employeeParam.Division_Id;
            employee.Position_Id = employeeParam.Position_Id;
            employee.UpdateDate = DateTimeOffset.Now.LocalDateTime;

            _context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
