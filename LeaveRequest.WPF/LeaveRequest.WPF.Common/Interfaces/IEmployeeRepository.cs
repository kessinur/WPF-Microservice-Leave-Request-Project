using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.WPF.Common.Interfaces
{
    public interface IEmployeeRepository
    {
        bool Insert(EmployeeParam employeeParam);
        bool Update(int? id, EmployeeParam employeeParam);
        bool Delete(int? id);
        List<Employee> Get();
        Employee Get(int? id);
    }
}
