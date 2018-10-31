using System.ComponentModel;

namespace Bookshelf.BL
{
	/// <summary>
	/// Represents a book
	/// </summary>
	public class Book
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Author { get; set; }

		public string ISBN { get; set; }

		[DisplayName("Loaned To")]
		public int? LoanedTo { get; set; }		

		public User LoanedToUser { get; set; }
	}	


}
