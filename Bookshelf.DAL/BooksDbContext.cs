using Bookshelf.BL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Bookshelf.DAL
{
	public class BooksDbContext : DbContext
	{
		public BooksDbContext(DbContextOptions<BooksDbContext> options)
		: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>()
			.HasKey(book => book.Id);

			modelBuilder.Entity<User>()
				.HasMany(user => user.LoanedBooks)
				.WithOne(book=>book.LoanedToUser)
				.HasForeignKey(book => book.LoanedTo);

			modelBuilder.Entity<Book>()			
			.HasIndex(book => new { book.ISBN })
			.IsUnique();

			modelBuilder.Entity<Book>()
				.HasData(
				new Book { Id = 1, Author = "Steve Kinney", ISBN = "9781617294143", Title = "Electron in Action" },
				new Book { Id = 2, Author = "François Chollet", ISBN = "9781617294433", Title = "Deep Learning with Python", LoanedTo = 2 },
				new Book { Id = 3, Author = "Morgan Bruce, Paulo A. Pereira", ISBN = "9781617294457", Title = "Microservices in Action" },
				new Book { Id = 4, Author = "Craig Walls", ISBN = "9781617294945", Title = "Spring in Action, Fifth Edition" },
				new Book { Id = 5, Author = "Alessandro Negro", ISBN = "9781617295645", Title = "Graph-Powered Machine Learning" });

			modelBuilder.Entity<User>()
				.HasData(
				new User { Id = 1, Name = "Scott Guthrie" },
				new User { Id = 2, Name = "Robert C. Martin" },
				new User { Id = 3, Name = "Damian Edwards" });

			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		
		}

		public DbSet<Book> Books { get; set; }

		public DbSet<User> Users { get; set; }
	}
}
