using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelf.BL
{
	/// <summary>
	/// A common repository should implement all this methods
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepository<T>
	{
		Task<List<T>> RetrieveAllAsync();

		Task<T> RetrieveByIdAsync(int id);

		Task SaveOrUpdateAsync(T entity);

		Task DeleteAsync(int id);
	}
}
