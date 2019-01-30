using LeaveRequest.WPF.DataAccess.Model;
using LeaveRequest.WPF.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.WPF.Common.Interfaces
{
    public interface IPositionRepository
    {
        bool Insert(PositionParam positionParam);
        bool Update(int? id, PositionParam positionParam);
        bool Delete(int? id);
        List<Position> Get();
        Position Get(int? id);
    }
}
