using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.BL
{
	public interface IUsersService
	{
		Task<List<User>> UsersAscList();
		
	}
}
