using DAL.Models;

namespace DAL.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
		public Task<List<Message>> GetMessageAsync(int id_chat);
	}
}
