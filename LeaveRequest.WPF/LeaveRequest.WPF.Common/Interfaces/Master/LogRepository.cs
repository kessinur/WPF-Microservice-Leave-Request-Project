using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;

namespace LeaveRequest.WPF.Common.Interfaces.Master
{
    public class LogRepository : ILogRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        public bool Delete(int? id)
        {
            var result = 0;
            Log log = Get(id);

            log.IsDelete = true;
            log.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<Log> Get()
        {
            var get = _context.Logs.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Log Get(int? id)
        {
            var get = _context.Logs.Find(id);
            return get;
        }

        public bool Insert(LogParam logParam)
        {
            var result = 0;
            Log log = new Log();

            log.Log_Date = DateTimeOffset.Now.LocalDateTime;
            log.Employee_Id = logParam.Employee_Id;
            log.CreateDate = DateTimeOffset.Now.LocalDateTime;

            _context.Logs.Add(log);
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
    }
}
