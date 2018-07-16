using Nop.Core.Domain.ChuyenPhatNhanh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data.Mapping.ChuyenPhatNhanh
{
    public class TienTrongKetMap : NopEntityTypeConfiguration<TienTrongKet>
    {
        public TienTrongKetMap()
        {
            this.ToTable("CV_TienTrongKet");
            this.HasKey(c => c.Id);

            this.Property(u => u.GhiChu).HasMaxLength(2000);


            this.HasRequired(c => c.vanphong)
              .WithMany()
              .HasForeignKey(c => c.VanPhongId);

            this.HasRequired(c => c.nhanvien)
              .WithMany()
              .HasForeignKey(c => c.NhanVienId);

        }
    }
}
