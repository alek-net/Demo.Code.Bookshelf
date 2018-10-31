using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.BL
{
	/// <summary>
	/// Basic bookshelf functions
	/// </summary>
	public interface IBookshelf
	{
		Task<List<Book>> BooksAsync();
		Task<Book> BookAsync(int bookId);
		Task<bool> LoanAsync(int bookId, int userId);
		Task<bool> ReturnAsync(int bookId);
	}


}
