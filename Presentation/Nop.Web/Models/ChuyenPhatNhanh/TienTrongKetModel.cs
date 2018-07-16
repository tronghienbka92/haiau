using Nop.Core.Domain.ChuyenPhatNhanh;
using Nop.Core.Domain.NhaXes;
using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Web.Models.ChuyenPhatNhanh
{
    public class TienTrongKetModel : BaseNopEntityModel
    {
        public decimal SoTienDauCa { get; set; }
        public decimal SoTien { get; set; }
        public decimal TienCuoc { get; set; }
        public int VanPhongId { get; set; }
        public virtual VanPhong vanphong { get; set; }
        public string TenVanPhong { get; set; }
        public int NhanVienId { get; set; }
        public virtual NhanVien nhanvien { get; set; }
        public string NhanVienHienTai { get; set; }
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