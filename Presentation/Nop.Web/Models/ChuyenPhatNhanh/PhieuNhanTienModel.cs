using FluentValidation.Attributes;
using Nop.Core.Domain.ChuyenPhatNhanh;
using Nop.Core.Domain.NhaXes;
using Nop.Web.Framework.Mvc;
using Nop.Web.Validators.ChuyenPhatNhanh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Web.Models.ChuyenPhatNhanh
{
    //[Validator(typeof(PhieuChuyenPhatValidator))]
    public class PhieuNhanTienModel : BaseNopEntityModel
    {
        public PhieuNhanTienModel()
        {
            NguoiGui = new KhachHang();
            NguoiNhan = new KhachHang();
        }
        public string MaPhieu { get; set; }
        public int VanPhongGuiId { get; set; }
        public virtual VanPhong VanPhongGui { get; set; }
        public string VanPhongGuiText { get; set; }
        public int VanPhongNhanId { get; set; }
        public virtual VanPhong VanPhongNhan { get; set; }
        public string VanPhongNhanText { get; set; }
        public int NguoiGuiId { get; set; }
        public virtual KhachHang NguoiGui { get; set; }
        public string NguoiGuiText { get; set; }
        public int NguoiNhanId { get; set; }
        public virtual KhachHang NguoiNhan { get; set; }
        public string NguoiNhanText { get; set; }
        public decimal SoTienBangSo { get; set; }
        public string SoTienBangChu { get; set; }
        public decimal CuocPhi { get; set; }
        public decimal TongCuocDaThanhToan { get; set;}
        public int NhanVienNhanTienId { get; set; }
        public virtual NhanVien NVGiaoDich { get; set; }
        public string NVGiaoDichText { get; set; }
        public int? NhanVienTraTienId { get; set; }
        public virtual NhanVien NVTraTien { get; set; }
        public string NVTraTienText { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayNhanTien { get; set; }
        public DateTime? NgayTraTien { get; set; }
        public string GhiChu { get; set; }
        public List<KhuVucVanPhongModel> khuvucvanphongs { get; set; }
        public int TrangThaiId { get; set; }
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
        public int DaIn {get;set;}
        public int DaSMS { get; set; }
    }
}