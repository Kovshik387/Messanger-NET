using DAL.Models;
using DAL.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class MessagerContext : DbContext
{
    public MessagerContext()
    {
    }

    public MessagerContext(DbContextOptions<MessagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Authorize> Authorizes { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Models.Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userschat> Userschats { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (optionsBuilder.IsConfigured == true) return;

		optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Messager;Username=postgres;Password=123;");

		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.ApplyConfiguration(new AuthorizeConfiguration());
		modelBuilder.ApplyConfiguration(new ChatConfiguration());
		modelBuilder.ApplyConfiguration(new MessageConfiguration());
		modelBuilder.ApplyConfiguration(new RoleConfiguration());
		modelBuilder.ApplyConfiguration(new TaskConfiguration());
		modelBuilder.ApplyConfiguration(new UserchatConfiguration());
		modelBuilder.ApplyConfiguration(new UserConfiguration());
	}
}
