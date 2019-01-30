using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.WPF.DataAccess.Param
{
    public class EmployeeParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Marriage { get; set; }
        public int Children_Total { get; set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public int Last_Year { get; set; }
        public int This_Year { get; set; }
        public int Manager_Id { get; set; }
        public string Religion { get; set; }
        public int Division_Id { get; set; }
        public int Position_Id { get; set; }
    }
}
