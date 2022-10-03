using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class ForumMapping:IEntityTypeConfiguration<Forum>
    {
        public void Configure(EntityTypeBuilder<Forum> builder)
        {
            builder.ToTable("forums");
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).HasColumnName("id");
            builder.Property(f => f.Name).HasColumnName("name");
            builder.Property(f => f.Slug).HasColumnName("slug");
        }
    }
}
