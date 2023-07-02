using System;
using System.Collections.Generic;
using DAL.EntityTypeConfiguration;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class MessagerContext : DbContext
{

    public virtual DbSet<Authorize> Authorizes { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Models.Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public MessagerContext(DbContextOptions<MessagerContext> options)
        : base(options) { }

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
		modelBuilder.ApplyConfiguration(new UserConfiguration());

		base.OnModelCreating(modelBuilder);
	}
}
