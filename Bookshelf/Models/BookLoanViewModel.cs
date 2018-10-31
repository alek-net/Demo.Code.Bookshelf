using Bookshelf.BL;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Models
{
	public class BookLoanViewModel
	{
		[Required]
		public int BookId { get; set; }

		public Book Book { get; set; }

		[Required]
		public int UserId { get; set; }

		public List<SelectListItem> Users { get; set; }
	}
}
