using System.Collections.Generic;

namespace Bookshelf.BL
{
	public class User
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<Book> LoanedBooks { get; set; }
	}


}
