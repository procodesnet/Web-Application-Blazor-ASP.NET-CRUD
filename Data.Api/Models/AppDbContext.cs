using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Api.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Record> Records { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Record>().HasData(new Record
			{
				Id = 1,
				Field = "One"
			});

			modelBuilder.Entity<Record>().HasData(new Record
			{
				Id = 2,
				Field = "Two"
			});

			modelBuilder.Entity<Record>().HasData(new Record
			{
				Id = 3,
				Field = "Three"
			});
		}
	}
}
