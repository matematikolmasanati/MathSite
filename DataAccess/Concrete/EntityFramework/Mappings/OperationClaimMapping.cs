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
    class OperationClaimMapping : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("operation_claims");
            builder.HasKey(op => op.Id);

            builder.Property(op => op.Id).HasColumnName("id");
            builder.Property(op => op.Name).HasColumnName("name");
        }
    }
}
