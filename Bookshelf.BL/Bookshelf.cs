using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bookshelf.BL
{
	public class Bookshelf : IBookshelf
	{
		IBooksRepository _booksRepository;

		public Bookshelf(IBooksRepository booksRepository)
		{
			_booksRepository = booksRepository;
		}

		public async Task<Book> BookAsync(int bookId)
		{
			return await _booksRepository.RetrieveBookAsync(bookId);
		}

		public async Task<List<Book>> BooksAsync()
		{
			return await _booksRepository.RetrieveBooksAsync();			
		}

		public async Task<bool> LoanAsync(int bookId, int userId)
		{
			var book = await _booksRepository.RetrieveBookAsync(bookId);

			if(book.LoanedTo != null || book.LoanedTo == userId)
			{
				return false;
			}

			book.LoanedTo = userId;

			await _booksRepository.SaveOrUpdateBookAsync(book);

			return true;
		}

		public async Task<bool> ReturnAsync(int bookId)
		{
			var book = await _booksRepository.RetrieveBookAsync(bookId);

			if (book.LoanedTo == null)
			{
				return false;
			}

			book.LoanedTo = null;

			await _booksRepository.SaveOrUpdateBookAsync(book);

			return true;
		}
	}


}
