using BLL.DTOs;
using BLL.Infrastructure.Mapping;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class UserChatService : IUserChatService
	{
		private readonly IUnitOfWork _unitOfWork;

		public UserChatService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

        public async Task AddUserChat(int id_user, int id_chat)
        {
            await _unitOfWork.UserChatsRepository.AddUserChat(id_user, id_chat);
			await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ChatUserDTO>> GetUserChatAsync(int id_user)
		{
			return Mapping.Mapper.Map<List<ChatUserDTO>>(await _unitOfWork.UserChatsRepository.GetUserChatsAsync(id_user));
		}

        public async Task<ChatUserDTO?> GetUsersGroupChatsAsync(int id_user, int id_other)
        {
			return Mapping.Mapper.Map<ChatUserDTO>(await _unitOfWork.UserChatsRepository.GetUsersGroupChats(id_user, id_other));
        }
    }
}
