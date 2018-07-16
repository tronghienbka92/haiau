using Nop.Core.Domain.ChuyenPhatNhanh;
using Nop.Core.Domain.NhaXes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data.Mapping.ChuyenPhatNhanh
{
    public class PhieuNhanTienMap : NopEntityTypeConfiguration<PhieuNhanTIen>
    {
        public PhieuNhanTienMap()
        {
            this.ToTable("CV_PhieuNhanTien");
            this.HasKey(c => c.Id);

            this.Property(u => u.MaPhieu).HasMaxLength(100);
            this.Property(u => u.GhiChu).HasMaxLength(2000);
            this.HasRequired(c => c.NVGiaoDich)
                .WithMany()
                .HasForeignKey(c => c.NhanVienNhanTienId);

            this.HasOptional(c => c.NVTraTien)
               .WithMany()
               .HasForeignKey(c => c.NhanVienTraTienId
               );

            this.HasRequired(c => c.VanPhongGui)
              .WithMany()
              .HasForeignKey(c => c.VanPhongGuiId);

            this.HasRequired(c => c.VanPhongNhan)
              .WithMany()
              .HasForeignKey(c => c.VanPhongNhanId);

            this.HasRequired(c => c.NguoiGui)
              .WithMany()
              .HasForeignKey(c => c.NguoiGuiId);

            this.HasRequired(c => c.NguoiNhan)
              .WithMany()
              .HasForeignKey(c => c.NguoiNhanId);
            this.Ignore(c => c.TrangThai);
        }
    }
}
