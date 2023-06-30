using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfiguration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Models.Task>
    {
        public void Configure(EntityTypeBuilder<Models.Task> entity)
        {
            entity.HasKey(e => e.IdTask).HasName("task_pkey");

            entity.ToTable("task");

            entity.HasIndex(e => e.IdMessage, "task_id_message_key").IsUnique();

            entity.Property(e => e.IdTask).HasColumnName("id_task");
            entity.Property(e => e.Daterealization)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("daterealization");
            entity.Property(e => e.Enddaterealization)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("enddaterealization");
            entity.Property(e => e.Factdaterealization)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("factdaterealization");
            entity.Property(e => e.IdMessage).HasColumnName("id_message");
            entity.Property(e => e.Isdone).HasColumnName("isdone");

            entity.HasOne(d => d.IdMessageNavigation).WithOne(p => p.Task)
                .HasForeignKey<Models.Task>(d => d.IdMessage)
                .HasConstraintName("task_id_message_fkey");
        }
    }
}
