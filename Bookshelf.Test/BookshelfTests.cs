using AutoFixture;
using AutoFixture.Xunit2;
using Bookshelf.BL;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bookshelf.Test
{
	public class BookshelfTests
	{
		[Fact]
		public async void GetBooksScenario()
		{
			Fixture fixture = new Fixture();

			fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
				.ForEach(b => fixture.Behaviors.Remove(b));
			fixture.Behaviors.Add(new OmitOnRecursionBehavior());

			var books = fixture.CreateMany<Book>().ToList();

			//arrange			
			var mock = new Mock<IBooksRepository>();

			mock.Setup(m => m.RetrieveBooksAsync()).ReturnsAsync(books);

			var booksRepository = mock.Object;
			
			var bookshelf = new Bookshelf.BL.Bookshelf(booksRepository);

			//act
			var booksResult = await bookshelf.BooksAsync();

			//asert
			booksResult.Count().Should().Equals(books.Count());			
		}

		[Theory, AutoData]
		public async void LoanBooksScenario(int userId)
		{
			Fixture fixture = new Fixture();

			fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
				.ForEach(b => fixture.Behaviors.Remove(b));
			fixture.Behaviors.Add(new OmitOnRecursionBehavior());

			var book = fixture.Create<Book>();

			//arrange
			int? expectedLoanedTo = 0;
			Book originalBook = book.SimpleClone();

				//make the book available to be loaned
			book.LoanedTo = null;
			
			var mock = new Mock<IBooksRepository>();

			mock.Setup(m => m.RetrieveBookAsync(book.Id))
				.ReturnsAsync(book);

				//when updating the book, loanedTo is checked
			mock.Setup(m => m.SaveOrUpdateBookAsync(It.IsAny<Book>()))
				.Returns(Task.CompletedTask)
				.Callback((Book b)=> { expectedLoanedTo = b.LoanedTo; });

			var booksRepository = mock.Object;

			var bookshelf = new Bookshelf.BL.Bookshelf(booksRepository);

			//act
			var booksResult = await bookshelf.LoanAsync(book.Id, userId);

			//asert		
			booksResult.Should().BeTrue();
			expectedLoanedTo.Should().Equals(userId);
			
				//make sure only one property changed
			book.Should().BeEquivalentTo(originalBook, options =>
				options.Excluding(b => b.LoanedTo));
		}
	}
}
