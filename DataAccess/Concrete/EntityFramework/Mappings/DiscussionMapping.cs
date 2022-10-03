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
    public class DiscussionMapping:IEntityTypeConfiguration<Discussion>
    {
        public void Configure(EntityTypeBuilder<Discussion> builder)
        {
            builder.ToTable("discussions");
            builder.HasKey(d=>d.Id);

            builder.Property(d => d.Id).HasColumnName("id");
            builder.Property(d => d.UserId).HasColumnName("user_id");
            builder.Property(d => d.ForumId).HasColumnName("forum_id");
            builder.Property(d => d.Title).HasColumnName("title");
            builder.Property(d => d.Question).HasColumnName("question");
            builder.Property(d => d.Slug).HasColumnName("slug");
            builder.Property(d => d.Tags).HasColumnName("tags");
            builder.Property(d => d.CreatedAt).HasColumnName("created_at");
            builder.Property(d => d.LastModified).HasColumnName("last_modified");
        }
    }
}
