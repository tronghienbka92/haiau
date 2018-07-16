using Nop.Core.Domain.ChuyenPhatNhanh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data.Mapping.ChuyenPhatNhanh
{
    public class LuanChuyenTienLogMap : NopEntityTypeConfiguration<LuanChuyenTienLog>
    {
        public LuanChuyenTienLogMap()
        {
            this.ToTable("CV_LuanChuyenTienLog");
            this.HasKey(c => c.Id);
            this.HasRequired(c => c.luanchuyentien)
                .WithMany(o => o.nhatkys)
                .HasForeignKey(c => c.LuanChuyenTienId);
           
        }
    }
}
