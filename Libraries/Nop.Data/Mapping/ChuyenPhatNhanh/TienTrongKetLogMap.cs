using Nop.Core.Domain.ChuyenPhatNhanh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data.Mapping.ChuyenPhatNhanh
{
    public class TienTrongKetLogMap : NopEntityTypeConfiguration<TienTrongKetLog>
    {
        public TienTrongKetLogMap()
        {
            this.ToTable("CV_TienTrongKetLog");
            this.HasKey(c => c.Id);
            this.HasRequired(c => c.tientrongket)
                .WithMany(o => o.nhatkys)
                .HasForeignKey(c => c.TienTrongKetId);

        }
    }
}
