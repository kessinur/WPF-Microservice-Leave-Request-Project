using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;

namespace LeaveRequest.WPF.Common.Interfaces.Master
{
    public class PositionRepository : IPositionRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        public bool Delete(int? id)
        {
            var result = 0;
            Position position = Get(id);

            position.IsDelete = true;
            position.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<Position> Get()
        {
            var get = _context.Positions.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Position Get(int? id)
        {
            var get = _context.Positions.Find(id);
            return get;
        }

        public bool Insert(PositionParam positionParam)
        {
            var result = 0;
            Position position = new Position();

            position.Name = positionParam.Name;
            position.CreateDate = DateTimeOffset.Now.LocalDateTime;

            _context.Positions.Add(position);
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

        public bool Update(int? id, PositionParam positionParam)
        {
            var result = 0;
            Position position = Get(id);

            position.Name = positionParam.Name;
            position.UpdateDate = DateTimeOffset.Now.LocalDateTime;

            _context.Entry(position).State = System.Data.Entity.EntityState.Modified;
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
        public List<Position> Search(string keyword, string category)
        {
            if (category == "Id")
            {
                var get = _context.Positions.Where(x => (x.IsDelete == false) && (x.Id.ToString().Contains(keyword))).ToList();
                return get;
            }
            else if (category == "Name")
            {
                var get = _context.Positions.Where(x => (x.IsDelete == false) && (x.Name.Contains(keyword))).ToList();
                return get;
            }
            else
            {
                var get = _context.Positions.Where(x => (x.IsDelete == false)).ToList();
                return get;
            }
        }

    }
}
