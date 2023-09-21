using KRWTransfer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KRWTransfer
{
	public class KRWDbContext : IdentityDbContext<UserModel>
	{
		public KRWDbContext(DbContextOptions<KRWDbContext> options) : base(options) { }

		public DbSet<UserModel> UserModel { get; set; }
		public DbSet<Account> Account { get; set; }
		public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
