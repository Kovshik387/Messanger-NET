using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class MessageRepository : IMessageRepository
	{
		private readonly MessagerContext _dbContext;
		public MessageRepository(MessagerContext messagerContext) { _dbContext = messagerContext; }
		public async System.Threading.Tasks.Task CreateAsync(Message item)
		{
			await _dbContext.Messages.AddAsync(item);
		}

		public Task<IEnumerable<Message>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Message?> GetItemAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Message>> GetMessageAsync(int id_chat)
		{
			return await _dbContext.Messages.Where(d => d.IdChat == id_chat).Include(s => s.IdUserNavigation).Include(u => u.IdChatNavigation).ToListAsync();
		}

		public System.Threading.Tasks.Task SaveChangesAsync()
		{
			throw new NotImplementedException();
		}

		public System.Threading.Tasks.Task UpdateAsync(Message item)
		{
			throw new NotImplementedException();
		}
	}
}
