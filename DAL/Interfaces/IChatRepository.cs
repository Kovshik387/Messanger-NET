using DAL.Models;

namespace DAL.Interfaces
{
    public interface IChatRepository : IRepository<Chat>
    {
        public Task<IEnumerable<Chat>> GetUserChats(int id_user);
        public Task<Chat> CreateChatAsync(Chat chat);
    }
}
