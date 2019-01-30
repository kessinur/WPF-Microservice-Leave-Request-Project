using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;

namespace LeaveRequest.WPF.Common.Interfaces.Master
{
    public class DivisionRepository : IDivisionRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        public bool Delete(int? id)
        {
            var result = 0;
            Division division = Get(id);

            division.IsDelete = true;
            division.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<Division> Get()
        {
            var get = _context.Divisions.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Division Get(int? id)
        {
            var get = _context.Divisions.Find(id);
            return get;
        }

        public bool Insert(DivisionParam divisionParam)
        {
            var result = 0;
            Division division = new Division();

            division.Name = divisionParam.Name;
            division.CreateDate = DateTimeOffset.Now.LocalDateTime;

            _context.Divisions.Add(division);
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

        public bool Update(int? id, DivisionParam divisionParam)
        {
            var result = 0;
            Division division = Get(id);

            division.Name = divisionParam.Name;
            division.UpdateDate = DateTimeOffset.Now.LocalDateTime;

            _context.Entry(division).State = System.Data.Entity.EntityState.Modified;
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
