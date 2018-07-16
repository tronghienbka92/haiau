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
    public class ListTienTrongKetModel : BaseNopEntityModel
    {
        public string TenVanPhongHienTai { get; set; }
        [UIHint("DateNgayTaoPhieuHang")]
        public DateTime? NgayTao { get; set; }
        [UIHint("DateNullable")]
        public DateTime? TuNgay { get; set; }
        [UIHint("DateNullable")]
        public DateTime? DenNgay { get; set; }
        public int VanPhongId { get; set; }
        public int TrangThaiId { get; set; }
        public string TrangThaiIds { get; set; }
    }
}