using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.WPF.Common.Interfaces
{
    public interface ILeaveRepository
    {
        bool Insert(LeaveParam leaveParam);
        bool Update(int? id, LeaveParam leaveParam);
        bool Delete(int? id);
        List<Leave> Get();
        Leave Get(int? id);
        List<Leave> Search(string keyword, string category);
    }
}
