using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthorizeRepository : IAuthorizeRepository
	{
		public System.Threading.Tasks.Task CreateAsync(Authorize item)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Authorize>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Authorize?> GetItemAsync(int id)
		{
			throw new NotImplementedException();
		}

		public System.Threading.Tasks.Task SaveChangesAsync()
		{
			throw new NotImplementedException();
		}

		public System.Threading.Tasks.Task UpdateAsync(Authorize item)
		{
			throw new NotImplementedException();
		}

		System.Threading.Tasks.Task IRepository<Authorize>.CreateAsync(Authorize item)
		{
			throw new NotImplementedException();
		}

		System.Threading.Tasks.Task IRepository<Authorize>.SaveChangesAsync()
		{
			throw new NotImplementedException();
		}

		System.Threading.Tasks.Task IRepository<Authorize>.UpdateAsync(Authorize item)
		{
			throw new NotImplementedException();
		}
	}
}
