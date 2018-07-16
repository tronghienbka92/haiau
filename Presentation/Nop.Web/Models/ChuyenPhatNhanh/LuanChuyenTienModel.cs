using Nop.Core.Domain.ChuyenPhatNhanh;
using Nop.Core.Domain.NhaXes;
using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Web.Models.ChuyenPhatNhanh
{
    public class LuanChuyenTienModel : BaseNopEntityModel
    {
        public LuanChuyenTienModel()
        {

        }
        public int VanPhongGuiId { get; set; }
        public virtual VanPhong vanphonggui { get; set; }
        public string VanPhongGuiText { get; set; }
        public int VanPhongNhanId { get; set; }
        public virtual VanPhong vanphongnhan { get; set; }
        public string VanPhongNhanText { get; set; }
        public decimal SoTien { get; set; }
        public DateTime NgayTao { get; set; }
        public string GhiChu { get; set; }
        public int NhanVienGiaoDichId { get; set; }
        public virtual NhanVien nhanviengiaodich { get; set; }
        public string NhanVienGiaoDichText { get; set; }
        public int? NhanVienNhanId { get; set; }
        public virtual NhanVien nhanviennhan { get; set; }
        public DateTime NgayChuyenTien { get; set; }
        public DateTime? NgayNhanTien { get; set; }
        public List<KhuVucVanPhongModel> khuvucvanphongs { get; set; }
        public int TrangThaiId { get; set; }
        public ENTrangThaiLuanChuyenTien TrangThai
        {
            get
            {
                return (ENTrangThaiLuanChuyenTien)this.TrangThaiId;
            }
            set
            {
                this.TrangThaiId = (int)value;
            }
        }
        private ICollection<LuanChuyenTienLog> _nhatkys;
        public virtual ICollection<LuanChuyenTienLog> nhatkys
        {
            get { return _nhatkys ?? (_nhatkys = new List<LuanChuyenTienLog>()); }
            protected set { _nhatkys = value; }
        }
    }
}