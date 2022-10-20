using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations.AuthEntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").HasKey(k => k.Id);
            builder.Property(p => p.UserId).HasColumnName("UserId");
            builder.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
            builder.HasOne(p => p.User);
            builder.HasOne(p => p.OperationClaim);
        }
    }
}
