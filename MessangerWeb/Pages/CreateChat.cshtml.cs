using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using MessangerWeb.Infrastructure.Mapping;
using MessangerWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessangerWeb.Pages
{
    [Authorize]
    public class CreateChatModel : PageModel
    {
        private readonly IUserChatService _userChatsService;
        private readonly IChatsService _chatService;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public CreateChatModel(IUserChatService userChatsService, IMapper mapper, IChatsService chatsService, IMessageService messageService) => (_userChatsService, _mapper, _chatService, _messageService) = (userChatsService, mapper, chatsService, messageService);

        public async Task<IActionResult> OnGet(int id_other)
        {
            int id_user = int.Parse(HttpContext.User.Identity!.Name!);

            var id = Mapping.Mapper.Map<UserchatView?>(await _userChatsService.GetUsersGroupChatsAsync(id_user, id_other));

            if (id != null) return RedirectToPage("a");

            var chat = await _chatService.AddAsync(new ChatDTO());

            await _userChatsService.AddUserChat(id_user, chat.IdChat!); await _userChatsService.AddUserChat(id_other, chat.IdChat!);

            await _messageService.AddMessageAsync(Mapping.Mapper.Map<MessageDTO>(new MessageView() 
            { Body = "",
              Datesend = DateTime.Now,
              IdUser = id_user,
              IdChat = chat.IdChat, 
             Isread = false
            }));

            await _messageService.AddMessageAsync(Mapping.Mapper.Map<MessageDTO>(new MessageView()
            {
                Body = "",
                Datesend = DateTime.Now,
                IdUser = id_other,
                IdChat = chat.IdChat,
                Isread = false
            }));

            return RedirectToPage("a");
        }
    }
}
