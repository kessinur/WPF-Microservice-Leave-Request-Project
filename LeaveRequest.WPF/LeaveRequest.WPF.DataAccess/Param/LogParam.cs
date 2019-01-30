using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.WPF.DataAccess.Param
{
    public class LogParam
    {
        public int Id { get; set; }
        public DateTimeOffset Log_Time { get; set; }
        public int Employee_Id { get; set; }
    }
}
