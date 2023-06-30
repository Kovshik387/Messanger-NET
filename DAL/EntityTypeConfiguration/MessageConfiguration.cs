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

            entity.HasIndex(e => e.Userfrom, "message_userfrom_key").IsUnique();

            entity.HasIndex(e => e.Userto, "message_userto_key").IsUnique();

            entity.Property(e => e.IdMess).HasColumnName("id_mess");
            entity.Property(e => e.Body)
                .HasMaxLength(300)
                .HasColumnName("body");
            entity.Property(e => e.Datesend)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datesend");
            entity.Property(e => e.IdChat).HasColumnName("id_chat");
            entity.Property(e => e.Isread).HasColumnName("isread");
            entity.Property(e => e.Userfrom).HasColumnName("userfrom");
            entity.Property(e => e.Userto).HasColumnName("userto");

            entity.HasOne(d => d.IdChatNavigation).WithMany(p => p.Messages)
                .HasForeignKey(d => d.IdChat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("message_id_chat_fkey");

            entity.HasOne(d => d.UserfromNavigation).WithOne(p => p.MessageUserfromNavigation)
                .HasForeignKey<Message>(d => d.Userfrom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("message_userfrom_fkey");

            entity.HasOne(d => d.UsertoNavigation).WithOne(p => p.MessageUsertoNavigation)
                .HasForeignKey<Message>(d => d.Userto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("message_userto_fkey");
        }
    }
}
