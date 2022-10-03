using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");


            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("id");
            builder.Property(u => u.Name).HasColumnName("name");
            builder.Property(u => u.UserName).HasColumnName("username");
            builder.Property(u => u.Description).HasColumnName("description");
            builder.Property(u => u.PasswordHash).HasColumnName("password_hash");
            builder.Property(u => u.PasswordSalt).HasColumnName("password_salt");
            builder.Property(u => u.Email).HasColumnName("email");
            builder.Property(u => u.PicturePath).HasColumnName("picture_path");
        }
        
    }
}
