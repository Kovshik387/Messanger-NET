using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IMessageService
	{
		public Task<List<MessageDTO>> GetMessageAsync(int id);
		public Task AddMessageAsync(MessageDTO message);
	}
}
