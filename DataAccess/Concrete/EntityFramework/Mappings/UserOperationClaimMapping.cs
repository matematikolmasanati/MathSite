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
    class UserOperationClaimMapping : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("user_operation_claims");
            builder.HasKey(uop => uop.Id);

            builder.Property(uop => uop.Id).HasColumnName("id");
            builder.Property(uop => uop.OperationClaimId).HasColumnName("operation_claim_id");
            builder.Property(uop => uop.UserId).HasColumnName("user_id");
        }
    }
}
