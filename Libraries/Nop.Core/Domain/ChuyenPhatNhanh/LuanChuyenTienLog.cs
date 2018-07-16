using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.ChuyenPhatNhanh
{
    public class LuanChuyenTienLog : BaseEntity
    {
        public String GhiChu { get; set; }
        public int LuanChuyenTienId { get; set; }
        public virtual LuanChuyenTien luanchuyentien { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
