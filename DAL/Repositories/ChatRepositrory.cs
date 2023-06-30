using DAL.Interfaces;
using DAL.Models;
using DAL.TemporalContext;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChatRepositrory : IChatRepository
    {
        private readonly MessagerContext _dbContext;
        public ChatRepositrory(MessagerContext messagerContext) { _dbContext = messagerContext;}

        public async System.Threading.Tasks.Task CreateAsync(Chat item)
        {
            await _dbContext.Chats.AddAsync(item);
        }

        public async Task<IEnumerable<Chat>> GetAllAsync()
        {
            return await _dbContext.Chats.ToListAsync();
        }

        public async Task<Chat?> GetItemAsync(int id)
        {
            return await _dbContext.Chats.Where(id_chat => id_chat.IdChat == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Chat>> GetUserChats(int id_user)
        {
            return await _dbContext.Chats.Where(id => id.IdUsertwo == id_user || id.IdUsertwo == id_user).ToListAsync(); 
        }

        public async System.Threading.Tasks.Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(Chat item)
        {
            await System.Threading.Tasks.Task.FromResult(_dbContext.Chats.Update(item));
        }
    }
}
