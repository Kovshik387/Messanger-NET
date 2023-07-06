using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
	public class ChatDTO
	{
		public int IdChat { get; set; }

		public virtual ICollection<MessageDTO> Messages { get; set; } = new List<MessageDTO>();
		public virtual ICollection<ChatUserDTO> Userschats { get; set; } = new List<ChatUserDTO>();
	}
}
