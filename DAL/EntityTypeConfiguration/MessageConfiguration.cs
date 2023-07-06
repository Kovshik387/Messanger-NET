using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Models;

namespace DAL.EntityTypeConfiguration
{
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public virtual void Configure(EntityTypeBuilder<Message> entity)
        {
			entity.HasKey(e => e.IdMess).HasName("message_pkey");

			entity.ToTable("message");

			entity.Property(e => e.IdMess).HasColumnName("id_mess");
			entity.Property(e => e.Body)
				.HasMaxLength(300)
				.HasColumnName("body");
			entity.Property(e => e.Datesend)
				.HasColumnType("timestamp without time zone")
				.HasColumnName("datesend");
			entity.Property(e => e.IdChat).HasColumnName("id_chat");
			entity.Property(e => e.IdUser).HasColumnName("id_user");
			entity.Property(e => e.Isread).HasColumnName("isread");

			entity.HasOne(d => d.IdChatNavigation).WithMany(p => p.Messages)
				.HasForeignKey(d => d.IdChat)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("message_id_chat_fkey");

			entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Messages)
				.HasForeignKey(d => d.IdUser)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("message_id_user_fkey");
		}
    }
}
