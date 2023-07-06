using BLL.Interfaces;
using MessangerWeb.Infrastructure.Mapping;
using MessangerWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessangerWeb.Pages
{
    public class FindUserModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty] public List<UserView> UsersView { get; set; } = null!;

        public FindUserModel(IUserService userService) => _userService = userService;

        public async Task OnGetAsync()
        {
            UsersView = Mapping.Mapper.Map<List<UserView>>(await _userService.GetAllUsersAsync());
        }

        public async Task OnPosAsync()
        {
            _userService.ToString();
        }
    }
}
