using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;

namespace LeaveRequest.WPF.Common.Interfaces.Master
{
    public class TakeLeaveRepository : ITakeLeaveRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        public bool Delete(int? id)
        {
            var result = 0;
            TakeLeave takeleave = Get(id);

            takeleave.IsDelete = true;
            takeleave.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<TakeLeave> Get()
        {
            var get = _context.TakeLeaves1.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public TakeLeave Get(int? id)
        {
            var get = _context.TakeLeaves1.Find(id);
            return get;
        }

        public bool Insert(TakeLeaveParam takeleaveParam)
        {
            var result = 0;
            TakeLeave takeleave = new TakeLeave();

            takeleave.Description = takeleaveParam.Description;
            takeleave.Date_Start = takeleaveParam.Date_Start;
            takeleave.Date_End = takeleaveParam.Date_End;
            takeleave.Approval_Status = takeleaveParam.Approval_Status;
            takeleave.Difference = takeleaveParam.Difference;
            takeleave.Date_Start_Special = takeleaveParam.Date_Start_Special;
            takeleave.Date_End_Special = takeleaveParam.Date_End_Special;
            takeleave.Difference_Special = takeleaveParam.Difference_Special;
            takeleave.Employee_Id = takeleaveParam.Employee_Id;
            takeleave.Leave_Id = takeleaveParam.Leave_Id;
            takeleave.CreateDate = DateTimeOffset.Now.LocalDateTime;

            _context.TakeLeaves1.Add(takeleave);
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

        public bool Update(int? id, TakeLeaveParam takeleaveParam)
        {
            var result = 0;
            TakeLeave takeleave = Get(id);

            takeleave.Description = takeleaveParam.Description;
            takeleave.Date_Start = takeleaveParam.Date_Start;
            takeleave.Date_End = takeleaveParam.Date_End;
            takeleave.Approval_Status = takeleaveParam.Approval_Status;
            takeleave.Difference = takeleaveParam.Difference;
            takeleave.Date_Start_Special = takeleaveParam.Date_Start_Special;
            takeleave.Date_End_Special = takeleaveParam.Date_End_Special;
            takeleave.Difference_Special = takeleaveParam.Difference_Special;
            takeleave.Employee_Id = takeleaveParam.Employee_Id;
            takeleave.Leave_Id = takeleaveParam.Leave_Id;
            takeleave.UpdateDate = DateTimeOffset.Now.LocalDateTime;

            _context.Entry(takeleave).State = System.Data.Entity.EntityState.Modified;
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
    }
}
