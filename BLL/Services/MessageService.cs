using BLL.DTOs;
using BLL.Infrastructure.Mapping;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class MessageService : IMessageService
	{
		private readonly IUnitOfWork _unitOfWork;

		public MessageService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async System.Threading.Tasks.Task AddMessageAsync(MessageDTO message)
        {
			await _unitOfWork.MessageRepository.CreateAsync(Mapping.Mapper.Map<Message>(message));
			await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<MessageDTO>> GetMessageAsync(int id)
		{
			return Mapping.Mapper.Map<List<MessageDTO>>(await _unitOfWork.MessageRepository.GetMessageAsync(id));
		}
	}
}
