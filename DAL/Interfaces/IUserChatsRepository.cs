using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IUserChatsRepository : IRepository<Userschat>
	{
		public Task<List<Userschat>> GetUserChatsAsync(int id_user);
		public System.Threading.Tasks.Task<Userschat?> GetUsersGroupChats(int id_user, int id_other);

		public System.Threading.Tasks.Task AddUserChat(int id_user, int id_chat);
    }
}
