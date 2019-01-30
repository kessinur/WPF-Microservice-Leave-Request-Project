using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;

namespace LeaveRequest.WPF.Common.Interfaces.Master
{
    public class LeaveRepository : ILeaveRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        public bool Delete(int? id)
        {
            var result = 0;
            Leave leave = Get(id);

            leave.IsDelete = true;
            leave.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<Leave> Get()
        {
            var get = _context.Leaves1.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Leave Get(int? id)
        {
            var get = _context.Leaves1.Find(id);
            return get;
        }

        public bool Insert(LeaveParam leaveParam)
        {
            var result = 0;
            Leave leave = new Leave();

            leave.Name = leaveParam.Name;
            leave.Status = leaveParam.Status;
            leave.Days = leaveParam.Days;
            leave.CreateDate = DateTimeOffset.Now.LocalDateTime;

            _context.Leaves1.Add(leave);
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

        public bool Update(int? id, LeaveParam leaveParam)
        {
            throw new NotImplementedException();
        }
    }
}
