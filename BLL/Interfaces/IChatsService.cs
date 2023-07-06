using BLL.DTOs;

namespace BLL.Interfaces
{
	public interface IChatsService
	{
		public Task<List<ChatDTO>> GetUserChat(int id_user);

		public Task<List<MessageDTO>> GetMessagesAsync(int id_chat);

		public Task<ChatDTO> AddAsync(ChatDTO chat);

    }
}
