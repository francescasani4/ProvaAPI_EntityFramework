using Microsoft.EntityFrameworkCore;
using ProvaAPI_EntityFramework.Model;

namespace ProvaAPI_EntityFramework.Database
{
	public class MyDbContext : DbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
		{
		}

		public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<LoanEntity> Loan { get; set; }

        public DbSet<UserModel> UsersModel { get; set; }
        public DbSet<BookModel> BooksModel { get; set; }
        public DbSet<LoanModel> LoanModel { get; set; }
    }
}

