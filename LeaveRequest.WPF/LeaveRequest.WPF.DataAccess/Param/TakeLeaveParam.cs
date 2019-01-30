using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.WPF.DataAccess.Param
{
    public class TakeLeaveParam
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date_Start { get; set; }
        public DateTimeOffset Date_End { get; set; }
        public string Approval_Status { get; set; }
        public int Difference { get; set; }
        public DateTimeOffset Date_Start_Special { get; set; }
        public DateTimeOffset Date_End_Special { get; set; }
        public int Difference_Special { get; set; }
        public int Employee_Id { get; set; }
        public int Leave_Id { get; set; }
     }
}
