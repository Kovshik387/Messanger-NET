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
			entity.Property(e => e.IdOwner).HasColumnName("id_owner");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.HasColumnName("name");

			entity.HasOne(d => d.IdOwnerNavigation).WithMany(p => p.Chats)
				.HasForeignKey(d => d.IdOwner)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("chat_id_owner_fkey");
		}
    }
}
