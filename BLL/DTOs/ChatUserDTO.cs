using DAL.Models;

namespace BLL.DTOs
{
	public class ChatUserDTO
	{
		public int IdUchat { get; set; }

		public int IdUser { get; set; }

		public int IdChat { get; set; }

		public virtual ChatDTO IdChatNavigation { get; set; } = null!;

		public virtual UserDTO IdUserNavigation { get; set; } = null!;
	}
}
