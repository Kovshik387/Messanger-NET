using DAL.Interfaces;
using DAL.Models;
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

        public async Task<Chat> CreateChatAsync(Chat chat)
        {
            await _dbContext.Chats.AddAsync(chat);



            await _dbContext.SaveChangesAsync();

            return chat; 
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
            /*            List<Chat> temp = new();
                        var a = await _dbContext.Userschats.Where(i => i.IdUser == id_user).Include(p => p.IdChatNavigation).ToListAsync();
                        foreach (var item in a) {

                            temp.Add(item.IdChatNavigation);
                           // item.IdChatNavigation.Messages.Add();
                        }
            */
            //await _dbContext.Userschats.Include(p => p.IdChatNavigation).Where(p => p.IdUser == id_user).ToListAsync();


            //Where(async id => id.IdChat == await _dbContext.Userschats.Where(id => id.IdUser == id_user))
            //var tempQuery = await _dbContext.Userschats.Include(c => c.IdChatNavigation).ThenInclude(m => m.Messages).Where(i => i.IdUser == id_user).ToListAsync();



            /*            return await _dbContext.Chats.
                            Include(c => c.Userschats).
                            Include(m => m.Messages).
                            AsSplitQuery().
                        ToListAsync();*/
            return null;
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
