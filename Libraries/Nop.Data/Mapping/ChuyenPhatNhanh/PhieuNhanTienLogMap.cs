using Nop.Core.Domain.ChuyenPhatNhanh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data.Mapping.ChuyenPhatNhanh
{
    public class PhieuNhanTienLogMap : NopEntityTypeConfiguration<PhieuNhanTienLog>
    {
        public PhieuNhanTienLogMap()
        {
            this.ToTable("CV_PhieuNhanTienLog");
            this.HasKey(c => c.Id);
            this.HasRequired(c => c.phieunhantien)
                .WithMany(o => o.nhatkys)
                .HasForeignKey(c => c.PhieuNhanTienId);
           
        }
    }
}
