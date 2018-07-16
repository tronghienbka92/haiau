using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.ChuyenPhatNhanh
{
    public class TienTrongKetLog : BaseEntity
    {
        public String GhiChu { get; set; }
        public int TienTrongKetId { get; set; }
        public virtual TienTrongKet tientrongket { get; set; }
        public int PhieuNhanTienId { get; set; }
        public int LuanChuyenTienId { get; set; }
        public DateTime NgayTao { get; set; }
        public decimal TienVon { get; set; }
        public decimal TienCuoc { get; set; }
        public decimal SoTien { get; set; }
        public decimal CuocPhi { get; set; }
    }
}
