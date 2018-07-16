using Nop.Core.Domain.NhaXes;
using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nop.Web.Models.ChuyenPhatNhanh
{
    public class ListPhieuChuyenTienModel : BaseNopEntityModel
    {
        public ListPhieuChuyenTienModel()
        {            
           
            isXepPhieu = false;
            VanPhongs = new List<SelectListItem>();
        }
        public string TenVanPhongHienTai { get; set; }
        public string MaPhieu { get; set; }
        public string TenNguoiGui { get; set; }
        public string HangHoaInfo { get; set; }
        public string ThongTinChuyen { get; set; }
        public string TenNguoiNhan { get; set; }
        [UIHint("DateNgayTaoPhieuHang")]
        public DateTime? NgayTao { get; set; }
        [UIHint("DateNullable")]
        public DateTime? TuNgay { get; set; }
        [UIHint("DateNullable")]
        public DateTime? DenNgay { get; set; }
        public int VanPhongNhanId { get; set; }
        public int VanPhongGuiId { get; set; }
        public int TrangThaiId { get; set; }
        public string TrangThaiIds { get; set; }
        public IList<SelectListItem> trangthais { get; set; }
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
        public string SoLenh { get; set; }
      
        public IList<SelectListItem> VanPhongs { get; set; }
        public bool isTraHang { get; set; }
        public bool isXepPhieu { get; set; }
    }
}