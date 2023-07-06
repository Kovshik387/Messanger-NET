using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfiguration
{
	public class UserchatConfiguration : IEntityTypeConfiguration<Userschat>
	{
		public void Configure(EntityTypeBuilder<Userschat> entity)
		{
			entity.HasKey(e => e.IdUchat).HasName("userschats_pkey");

			entity.ToTable("userschats");

			entity.Property(e => e.IdUchat).HasColumnName("id_uchat");
			entity.Property(e => e.IdChat).HasColumnName("id_chat");
			entity.Property(e => e.IdUser).HasColumnName("id_user");

			entity.HasOne(d => d.IdChatNavigation).WithMany(p => p.Userschats)
				.HasForeignKey(d => d.IdChat)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("userschats_id_chat_fkey");

			entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Userschats)
				.HasForeignKey(d => d.IdUser)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("userschats_id_user_fkey");
		}
	}
}
