using Bookshelf.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Bookshelf.Test
{
	public class BooksRepositoryTests
	{
		[Fact]
		public void RetrieveBooksScenarioBasic()
		{
			var options = new DbContextOptionsBuilder<BooksDbContext>()
				.UseInMemoryDatabase(databaseName: "RetrieveBooksScenarioBasic")
				.Options;

			// Insert seed data into the database using one instance of the context
			using (var ctx = new BooksDbContext(options))
			{
				ctx.Database.EnsureCreated();				
			}

			// Use a clean instance of the context to run the test
			using (var ctx = new BooksDbContext(options))
			{
				var repo = new BooksRepository(ctx);

				var books = repo.RetrieveBooksAsync().Result;

				Assert.Equal(5, books.Count());				
			}
		}

		[Fact]
		public void DeleteBookScenarioBasic()
		{
			var options = new DbContextOptionsBuilder<BooksDbContext>()
				.UseInMemoryDatabase(databaseName: "DeleteBookScenarioBasic")
				.Options;

			// Insert seed data into the database using one instance of the context
			using (var ctx = new BooksDbContext(options))
			{
				ctx.Database.EnsureCreated();
			}

			// Use a clean instance of the context to run the test
			using (var ctx = new BooksDbContext(options))
			{
				var repo = new BooksRepository(ctx);

				repo.DeleteBookAsync(3).Wait();	
			}

			// Use a clean instance of the context to run the test
			using (var ctx = new BooksDbContext(options))
			{
				var repo = new BooksRepository(ctx);

				var books = repo.RetrieveBooksAsync().Result;

				Assert.Equal(4, books.Count());
			}
		}
	}
}
