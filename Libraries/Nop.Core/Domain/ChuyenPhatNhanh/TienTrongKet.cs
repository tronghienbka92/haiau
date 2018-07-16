using Nop.Core.Domain.NhaXes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.ChuyenPhatNhanh
{
    public class TienTrongKet :BaseEntity
    {
        public decimal SoTienDauCa { get; set; }
        public decimal SoTien { get; set; }
        public decimal TienCuoc { get; set; }
        public int VanPhongId { get; set;}
        public virtual VanPhong vanphong { get; set; }
        public int NhanVienId { get; set; }
        public virtual NhanVien nhanvien { get; set; }
        public DateTime NgayTao { get; set; }
        public string GhiChu { get; set; }
        private ICollection<TienTrongKetLog> _nhatkys;
        public virtual ICollection<TienTrongKetLog> nhatkys
        {
            get { return _nhatkys ?? (_nhatkys = new List<TienTrongKetLog>()); }
            protected set { _nhatkys = value; }
        }
    }
}
