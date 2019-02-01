using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;
using System.Data.Entity.Validation;

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
            try {
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
            }
            catch (DbEntityValidationException e)
            {
                Console.Write(e.EntityValidationErrors);
            }
            return false;
        }
        public bool Update(int? id, LeaveParam leaveParam)
        {
            var result = 0;
            Leave leave = Get(id);

            leave.Name = leaveParam.Name;
            leave.Status = leaveParam.Status;
            leave.Days = leaveParam.Days;
            leave.UpdateDate = DateTimeOffset.Now.LocalDateTime;

            _context.Entry(leave).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Leave> Search(string keyword, string category)
        {
            if (category == "Id")
            {
                var get = _context.Leaves1.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keyword))).ToList();
                return get;
            }
            else if (category == "Name")
            {
                var get = _context.Leaves1.Where(x => (x.IsDelete == false) && (x.Name.Contains(keyword))).ToList();
                return get;
            }
            else
            {
                var get = _context.Leaves1.Where(x => (x.IsDelete == false)).ToList();
                return get;
            }
        }
    }
}
