using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.BL
{
	public class UsersService : IUsersService
	{
		IUsersRepository _usersRepository;

		public UsersService(IUsersRepository usersRepository)
		{
			_usersRepository = usersRepository;
		}

		public async Task<List<User>> UsersAscList()
		{
			return (await _usersRepository.RetrieveAllAsync())
				.OrderBy(user => user.Name)
				.ToList();
				
		}
	}
}
