﻿using Nop.Core.Domain.NhaXes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.ChuyenPhatNhanh
{
    public class LuanChuyenTien :BaseEntity
    {
        public LuanChuyenTien()
        {

        }
        public int VanPhongGuiId { get; set; }
        public virtual VanPhong vanphonggui { get; set; }
        public int VanPhongNhanId { get; set; }
        public virtual VanPhong vanphongnhan { get; set; }
        public decimal SoTien { get; set; }
        public DateTime NgayTao { get; set; }
        public string GhiChu { get; set; }
        public int NhanVienGiaoDichId { get; set; }
        public virtual NhanVien nhanviengiaodich { get; set; }
        public int? NhanVienNhanId { get; set; }
        public virtual NhanVien nhanviennhan { get; set; }
        public DateTime NgayChuyenTien { get; set; }
        public DateTime? NgayNhanTien { get; set; }
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
