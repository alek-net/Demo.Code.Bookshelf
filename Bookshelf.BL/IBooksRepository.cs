using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.BL
{
	public interface IBooksRepository
	{
		Task<List<Book>> RetrieveBooksAsync();

		Task<Book> RetrieveBookAsync(int bookId);

		Task SaveOrUpdateBookAsync(Book book);

		Task DeleteBookAsync(int bookId);
	}


}
