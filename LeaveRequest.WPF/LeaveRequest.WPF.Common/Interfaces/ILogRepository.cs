using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.WPF.Common.Interfaces
{
    public interface ILogRepository
    {
        bool Insert(LogParam logParam);

        //bool Update(int? id, LogParam logParam);

        bool Delete(int? id);
        List<Log> Get();
        Log Get(int? id);
    }
}
