using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Models;
namespace DAL.EntityTypeConfiguration
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> entity)
        {
            entity.HasKey(e => e.IdChat).HasName("chat_pkey");

            entity.ToTable("chat");

            entity.Property(e => e.IdChat).HasColumnName("id_chat");
            entity.Property(e => e.IdUserone).HasColumnName("id_userone");
            entity.Property(e => e.IdUsertwo).HasColumnName("id_usertwo");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdUseroneNavigation).WithMany(p => p.ChatIdUseroneNavigations)
                .HasForeignKey(d => d.IdUserone)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chat_id_userone_fkey");

            entity.HasOne(d => d.IdUsertwoNavigation).WithMany(p => p.ChatIdUsertwoNavigations)
                .HasForeignKey(d => d.IdUsertwo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chat_id_usertwo_fkey");
        }
    }
}
