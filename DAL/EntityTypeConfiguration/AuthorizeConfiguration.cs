using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Models;

namespace DAL.EntityTypeConfiguration
{
    public class AuthorizeConfiguration : IEntityTypeConfiguration<Authorize>
    {
        public AuthorizeConfiguration() : base() { }
        public virtual void Configure(EntityTypeBuilder<Authorize> entity)
        {
            entity.HasKey(e => e.IdAuthorize).HasName("authorize_pkey");

            entity.ToTable("authorize");

            entity.HasIndex(e => e.IdRole, "authorize_id_role_key").IsUnique();

            entity.Property(e => e.IdAuthorize).HasColumnName("id_authorize");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .HasColumnName("password");

            entity.HasOne(d => d.IdRoleNavigation).WithOne(p => p.Authorize)
                .HasForeignKey<Authorize>(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("authorize_id_role_fkey");
        }
    }
}
