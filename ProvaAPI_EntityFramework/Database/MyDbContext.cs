using Microsoft.EntityFrameworkCore;
using ProvaAPI_EntityFramework.Model;

namespace ProvaAPI_EntityFramework.Database
{
	public class MyDbContext : DbContext
	{
        private readonly FakeDatabase _fakeDatabase;

        public MyDbContext(DbContextOptions<MyDbContext> options, FakeDatabase fakeDatabase) : base(options)
		{
            _fakeDatabase = fakeDatabase;
		}

		public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<LoanEntity> Loan { get; set; }

        public DbSet<UserModel> UsersModel { get; set; }
        public DbSet<BookModel> BooksModel { get; set; }
        public DbSet<LoanModel> LoanModel { get; set; }
    }
}

