using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bookshelf.Models;
using Bookshelf.BL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookshelf.Controllers
{
	public class HomeController : Controller
	{
		IBookshelf _bookshelf;
		IUsersService _usersService;

		public HomeController(
			IBookshelf bookshelf,
			IUsersService usersService)
		{
			_bookshelf = bookshelf;
			_usersService = usersService;
		}

		public async Task<IActionResult> Index()
		{
			var books = await _bookshelf.BooksAsync();

			return View(books);
		}

		// GET: Books/Loan/5
		public async Task<IActionResult> Loan(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var taskGetBook = _bookshelf.BookAsync(id.Value);
			var taskGetUsers = _usersService.UsersAscList();

			await Task.WhenAll(taskGetBook, taskGetUsers);

			var book = taskGetBook.Result;// await _bookshelf.BookAsync(id.Value);

			if (book == null)
			{
				return NotFound();
			}

			var users = taskGetUsers.Result;// await _usersService.UsersAscList();

			var usersSelectListItems =
				users.Select(user =>
					new SelectListItem()
					{
						Value = user.Id.ToString(),
						Text = user.Name
					})
				.ToList();

			var model = new BookLoanViewModel
			{
				Book = book,
				BookId = id.Value,
				Users = usersSelectListItems
			};

			return View(model);
		}

		// POST: Books/Loan/5		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Loan([Bind("Id,LoanedTo")]Book book)
		{
			await _bookshelf.LoanAsync(book.Id , book.LoanedTo.Value);
			
			return RedirectToAction(nameof(Index));	
		}

		// GET: Books/Return/5
		public async Task<IActionResult> Return(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var book = await _bookshelf.BookAsync(id.Value);

			if (book == null)
			{
				return NotFound();
			}

			return View(book);
		}

		// POST: Books/Return/5		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Return(int id)
		{
			await _bookshelf.ReturnAsync(id);

			return RedirectToAction(nameof(Index));
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
