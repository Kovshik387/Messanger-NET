using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public class TaskRepository : ITaskRepository
	{
		private readonly MessagerContext _dbContext;

		public TaskRepository(MessagerContext dbContext) => _dbContext = dbContext;
		public System.Threading.Tasks.Task CreateAsync(Models.Task item)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Models.Task>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Models.Task?> GetItemAsync(int id)
		{
			throw new NotImplementedException();
		}

		public System.Threading.Tasks.Task SaveChangesAsync()
		{
			throw new NotImplementedException();
		}

		public System.Threading.Tasks.Task UpdateAsync(Models.Task item)
		{
			throw new NotImplementedException();
		}
	}
}
