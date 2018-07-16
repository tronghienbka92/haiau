using Nop.Core.Domain.ChuyenPhatNhanh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data.Mapping.ChuyenPhatNhanh
{
    public class LuanChuyenTienMap : NopEntityTypeConfiguration<LuanChuyenTien>
    {
        public LuanChuyenTienMap()
        {
            this.ToTable("CV_LuanChuyenTien");
            this.HasKey(c => c.Id);

            this.Property(u => u.GhiChu).HasMaxLength(2000);


            this.HasRequired(c => c.vanphonggui)
              .WithMany()
              .HasForeignKey(c => c.VanPhongGuiId);

            this.HasRequired(c => c.vanphongnhan)
              .WithMany()
              .HasForeignKey(c => c.VanPhongNhanId);

            this.HasRequired(c => c.nhanviengiaodich)
              .WithMany()
              .HasForeignKey(c => c.NhanVienGiaoDichId);
            this.Ignore(c => c.TrangThai);
        }
    }
}
