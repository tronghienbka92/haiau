using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.ChuyenPhatNhanh
{
    public class PhieuNhanTienLog : BaseEntity
    {
        public String GhiChu { get; set; }
        public int PhieuNhanTienId { get; set; }
        public virtual PhieuNhanTIen phieunhantien { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
