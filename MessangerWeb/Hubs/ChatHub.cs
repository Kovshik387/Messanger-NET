using BLL.DTOs;
using BLL.Interfaces;
using MessangerWeb.Infrastructure.Mapping;
using MessangerWeb.Models;
using Microsoft.AspNetCore.SignalR;

namespace MessangerWeb.Hubs
{
	public class ChatHub : Hub
	{
		private readonly IMessageService _messageService;
		public ChatHub(IMessageService messageService) => _messageService = messageService;

		public async Task JoinChat(int chat_id)
		{
			await Groups.AddToGroupAsync(this.Context.ConnectionId, chat_id.ToString());
			await this.Clients.Group(chat_id.ToString()).SendAsync("JoinGroup", chat_id);
		}

		public async Task SendMessage(string user, string message, int chat_id)
		{
			await Clients.Group(chat_id.ToString()).SendAsync("ReceiveMessage", user, message);
			await _messageService.AddMessageAsync(Mapping.Mapper.Map<MessageDTO>(
				new MessageView()
			{
				Body = message,
				Datesend = DateTime.Now,
				IdUser = int.Parse(user),
				Isread = true,
				IdChat = chat_id
			}));

			Console.WriteLine($"{message} отправил {user}");
		}
	}
}
