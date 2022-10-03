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
    public class ContentMapping : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable("contents");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.UserId).HasColumnName("user_id");
            builder.Property(c => c.Description).HasColumnName("description");
            builder.Property(c => c.Title).HasColumnName("title");
            builder.Property(c => c.Slug).HasColumnName("slug");
            builder.Property(c => c.Photos).HasColumnName("photos");
            builder.Property(c => c.CreatedAt).HasColumnName("created_at");
        }
    }
}
