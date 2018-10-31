using Bookshelf.BL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.DAL
{
	/// <summary>
	/// EF core books repository
	/// </summary>
	public class BooksRepository : IBooksRepository
	{
		BooksDbContext _dataContext;

		public BooksRepository(BooksDbContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task DeleteBookAsync(int bookId)
		{
			var book = _dataContext.Books.Find(bookId);

			if (book == null)
			{
				return;
			}

			_dataContext.Books.Remove(book);

			await _dataContext.SaveChangesAsync();
		}

		public async Task<Book> RetrieveBookAsync(int bookId)
		{
			var book = await _dataContext.Books.FindAsync(bookId);

			return book;
		}

		public async Task<List<Book>> RetrieveBooksAsync()
		{
			return await _dataContext.Books.Include(book=>book.LoanedToUser).ToListAsync();			 
		}

		public async Task SaveOrUpdateBookAsync(Book book)
		{
			_dataContext.Books.Attach(book);

			await _dataContext.SaveChangesAsync();
		}
	}
}
