using DAL.Interfaces;
using DAL.Models;
using DAL.TemporalContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RoleRepository : IRoleRepository
	{
		private readonly MessagerContext _dbContext;

		public RoleRepository(MessagerContext dbContext) => _dbContext = dbContext;
		public System.Threading.Tasks.Task CreateAsync(Role item)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Role>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Role?> GetItemAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Role?> GetRoleAsync(string type)
		{
			return await _dbContext.Roles.FirstOrDefaultAsync(p => p.Type == type);
		}

		public System.Threading.Tasks.Task SaveChangesAsync()
		{
			throw new NotImplementedException();
		}

		public System.Threading.Tasks.Task UpdateAsync(Role item)
		{
			throw new NotImplementedException();
		}
	}
}
