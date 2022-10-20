using Core.Security.Entities;
using Core.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations.AuthEntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(64);
            builder.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(64);
            builder.Property(p => p.Email).HasColumnName("Email").HasMaxLength(128);
            builder.Property(p => p.Status).HasColumnName("Status");
            builder.Property(p => p.PasswordHash).HasColumnName("PasswordHash").HasMaxLength(512);
            builder.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt").HasMaxLength(512);
            builder.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
            builder.HasMany(u => u.UserOperationClaims);
            builder.HasMany(u => u.RefreshTokens);

            HashingHelper.CreatePasswordHash("Pass123", out var passwordHash, out var passwordSalt);
        }
    }
}
