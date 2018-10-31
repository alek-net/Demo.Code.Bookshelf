using Bookshelf.BL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.DAL
{
	public class UsersRepository : IUsersRepository
	{
		BooksDbContext _dataContext;

		public UsersRepository(BooksDbContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task DeleteAsync(int id)
		{
			var user = _dataContext.Users.Find(id);

			if (user == null)
			{
				return;
			}

			_dataContext.Users.Remove(user);

			await _dataContext.SaveChangesAsync();
		}

		public async Task<List<User>> RetrieveAllAsync()
		{
			return await _dataContext.Users.ToListAsync();
		}

		public async Task<User> RetrieveByIdAsync(int id)
		{
			return await _dataContext.Users.FindAsync(id);
		}

		public async Task SaveOrUpdateAsync(User entity)
		{
			_dataContext.Users.Attach(entity);

			await _dataContext.SaveChangesAsync();
		}
	}
}
