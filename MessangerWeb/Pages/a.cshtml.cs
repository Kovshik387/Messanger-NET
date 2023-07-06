using AutoMapper;
using BLL.Interfaces;
using MessangerWeb.Infrastructure.Mapping;
using MessangerWeb.Models;
using MessangerWeb.Pages.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessangerWeb.Pages
{
    [Authorize]
    public class aModel : PageModel
    {
		private readonly IMapper _mapper;
		private readonly ILogger<LoginModel> _logger;
		private readonly IUserChatService _chatsService;
		private readonly IAuthentificationService _authentificationService;
		private readonly IMessageService _messageService;
		private readonly IUserService _userService;

		[BindProperty]
		public List<UserchatView> Chat { get; set; } = null!;

		[BindProperty]
		public List<MessageView> Messages { get; set; } = null!;

		[BindProperty]
		public UserView CurrentUser { get; set; } = null!;

		[BindProperty]
		public UserView AnotherUser { get; set; } = new();

		public aModel(IMapper mapper, ILogger<LoginModel> logger, IUserChatService chatsService, IAuthentificationService authentificationService, IMessageService message, IUserService userService) =>
            (_mapper, _logger, _chatsService, _authentificationService, _messageService, _userService) = (mapper, logger, chatsService, authentificationService, message, userService);
		
        public async Task OnGetAsync() => await GetSideBar();

		public async Task OnGetChat(int id_chat)
		{
			await GetSideBar();

			AnotherUser = Mapping.Mapper.Map<UserView>(await _userService.GetAnotherUserAsync(int.Parse(this.HttpContext.User!.Identity!.Name!), id_chat));

			Messages = Mapping.Mapper.Map<List<MessageView>>(await _messageService.GetMessageAsync(id_chat));
		}

		private async Task GetSideBar()
		{
            CurrentUser = Mapping.Mapper.Map<UserView>(await _userService.GetUserAsync(int.Parse(this.HttpContext.User!.Identity!.Name!)));
            
			var user_id = this.HttpContext.User!.Identity!.Name == null ? 0 : int.Parse(this.HttpContext.User.Identity.Name);
            Chat = Mapping.Mapper.Map<List<UserchatView>>(await _chatsService.GetUserChatAsync(user_id));

            foreach (var chat in Chat)
            {
                chat.IdUserNavigation = Mapping.Mapper.Map<UserView>(await _authentificationService.GetUserProfileImage(id_user: chat.IdChatNavigation!.Messages[0]!.IdUser));
            }
        }
	}
}
