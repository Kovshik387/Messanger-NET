using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IUserChatService
	{
		public Task<List<ChatUserDTO>> GetUserChatAsync(int id_user);

        public System.Threading.Tasks.Task<ChatUserDTO?> GetUsersGroupChatsAsync(int id_user, int id_other);

		public Task AddUserChat(int id_user, int id_chat);
    }
}
