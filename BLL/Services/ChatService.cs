using AutoMapper;
using BLL.DTOs;
using BLL.Infrastructure.Mapping;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
	public class ChatService : IChatsService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ChatService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<MessageDTO>> GetMessagesAsync(int id_chat)
		{
			return Mapping.Mapper.Map<List<MessageDTO>>(await _unitOfWork.MessageRepository.GetMessageAsync(id_chat));
		}

		public async Task<List<ChatDTO>> GetUserChat(int id_user)
		{
			return Mapping.Mapper.Map<List<ChatDTO>>(await _unitOfWork.ChatRepository.GetUserChats(id_user));
		}

        public async Task<ChatDTO> AddAsync(ChatDTO chat)
		{
			var temp_old = await _unitOfWork.ChatRepository.CreateChatAsync(Mapping.Mapper.Map<Chat>(chat));

			await _unitOfWork.SaveChangesAsync();

			var temp = Mapping.Mapper.Map<ChatDTO>(temp_old);
            return temp;
		}
    }
}
