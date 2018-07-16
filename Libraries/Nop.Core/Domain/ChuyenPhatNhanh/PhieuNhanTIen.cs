using Nop.Core.Domain.NhaXes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.ChuyenPhatNhanh
{
    public class PhieuNhanTIen : BaseEntity
    {
        public PhieuNhanTIen()
        {
            
        }
        public string MaPhieu { get; set; }
        public int VanPhongGuiId { get; set; }
        public virtual VanPhong VanPhongGui { get; set; }
        public int VanPhongNhanId { get; set; }
        public virtual VanPhong VanPhongNhan { get; set; }
        public int NguoiGuiId { get; set; }
        public virtual KhachHang NguoiGui { get; set; }
        public int NguoiNhanId { get; set; }
        public virtual KhachHang NguoiNhan { get; set; }
        public decimal SoTienBangSo { get; set; }
        public decimal TongCuocDaThanhTOan { get; set; }
        public string SoTienBangChu { get; set; }
        public decimal CuocPhi { get; set; }
        public int NhanVienNhanTienId { get; set; }
        public virtual NhanVien NVGiaoDich { get; set; }
        public int? NhanVienTraTienId { get; set; }
        public virtual NhanVien NVTraTien { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayNhanTien { get; set; }
        public DateTime? NgayTraTien { get; set; }
        public DateTime? NgayDenVanPhongNhan { get; set; }
        public string GhiChu { get; set; }
        public int TrangThaiId { get; set; }
        public int DaIn { get; set; }
        public int DaSMS { get; set; }
        public ENTrangThaiChuyenTien TrangThai
        {
            get
            {
                return (ENTrangThaiChuyenTien)this.TrangThaiId;
            }
            set
            {
                this.TrangThaiId = (int)value;
            }
        }
        private ICollection<PhieuNhanTienLog> _nhatkys;
        public virtual ICollection<PhieuNhanTienLog> nhatkys
        {
            get { return _nhatkys ?? (_nhatkys = new List<PhieuNhanTienLog>()); }
            protected set { _nhatkys = value; }
        }
    }
}
