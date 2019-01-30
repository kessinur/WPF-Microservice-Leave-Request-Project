using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.WPF.Common.Interfaces
{
    public interface ITakeLeaveRepository
    {
        bool Insert(TakeLeaveParam takeleaveParam);
        bool Update(int? id, TakeLeaveParam takeleaveParam);
        bool Delete(int? id);
        List<TakeLeave> Get();
        TakeLeave Get(int? id);
    }
}
