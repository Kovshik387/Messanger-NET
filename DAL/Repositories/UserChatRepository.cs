using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public class UserChatRepository : IUserChatsRepository
	{
		private readonly MessagerContext _dbContext;

		public UserChatRepository(MessagerContext dbContext) => _dbContext = dbContext;
		public System.Threading.Tasks.Task CreateAsync(Userschat item)
		{
			throw new NotImplementedException();
		}

		public async System.Threading.Tasks.Task<Userschat?> GetUsersGroupChats(int id_user, int id_other)
		{
			var temp = await _dbContext.Userschats.Where(s => s.IdUser == id_user || s.IdUser == id_other).GroupBy(s => s.IdChat).Where(c => c.Count() > 1).Select(k => k.Key).FirstOrDefaultAsync();
			
            return await _dbContext.Userschats.FirstOrDefaultAsync(s => s.IdChat == temp);
		}

		public Task<IEnumerable<Userschat>> GetAllAsync()
		{
			throw new NotImplementedException();
		}



		public Task<Userschat?> GetItemAsync(int id)
		{
			throw new NotImplementedException();
		}

		public System.Threading.Tasks.Task SaveChangesAsync()
		{
			throw new NotImplementedException();
		}

		public System.Threading.Tasks.Task UpdateAsync(Userschat item)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Userschat>> GetUserChatsAsync(int id_user)
		{
			return await _dbContext.Userschats.Where(id => id.IdUser == id_user).Include(m => m.IdChatNavigation).ThenInclude(m => m.Messages.Where(id => id.IdUser != id_user)).ThenInclude(m => m.IdUserNavigation).ToListAsync();
		}

        public async System.Threading.Tasks.Task AddUserChat(int id_user, int id_chat)
        {
           await _dbContext.Userschats.AddAsync(new Userschat() { IdChat = id_chat, IdUser = id_user });
        }

        /*		public async Task<List<Userschat>> GetUserChatsAsync(int id_user)
                {
                    //return await _dbContext.Userschats.Include(chat => chat.IdChatNavigation).Include(uchat => uchat.IdChatNavigation).Where(c => c.IdUserNavigation.IdUser == id_user).FirstOrDefaultAsync();
                    return await _dbContext.Userschats.Include(c => c.IdChatNavigation).ThenInclude(m => m.Messages).Where(i => i.IdUser == id_user).ToListAsync();
                }*/
    }
}
