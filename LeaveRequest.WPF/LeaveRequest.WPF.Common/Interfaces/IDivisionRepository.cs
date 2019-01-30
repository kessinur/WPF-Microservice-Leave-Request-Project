using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.WPF.Common.Interfaces
{
    public interface IDivisionRepository
    {
        bool Insert(DivisionParam divisionParam);
        bool Update(int? id, DivisionParam divisionParam);
        bool Delete(int? id);
        List<Division> Get();
        Division Get(int? id);
    }
}
