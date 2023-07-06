using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Models;
namespace DAL.EntityTypeConfiguration
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> entity)
        {
			entity.HasKey(e => e.IdChat).HasName("chats_pkey");

			entity.ToTable("chats");

			entity.Property(e => e.IdChat).HasColumnName("id_chat");
		}
    }
}
