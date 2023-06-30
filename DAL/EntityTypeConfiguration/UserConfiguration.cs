using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Models;

namespace DAL.EntityTypeConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.IdUser).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.IdAuthorize, "users_id_authorize_key").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Dateendwork).HasColumnName("dateendwork");
            entity.Property(e => e.Datestartwork).HasColumnName("datestartwork");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .HasColumnName("email");
            entity.Property(e => e.IdAuthorize).HasColumnName("id_authorize");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasMaxLength(40)
                .HasColumnName("surname");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(40)
                .HasColumnName("patronymic");
            entity.Property(e => e.Profileimage)
                .HasMaxLength(300)
                .HasColumnName("profileimage");

            entity.HasOne(d => d.IdAuthorizeNavigation).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.IdAuthorize)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_id_authorize_fkey");
        }
    }
}
