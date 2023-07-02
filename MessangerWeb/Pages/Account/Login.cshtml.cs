using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using AutoMapper;
using BLL.Interfaces;
using MessangerWeb.Models;
using DAL.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using BLL.DTOs;

namespace MessangerWeb.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly IAuthentificationService _authentication;

        private readonly IMapper _mapper;
        private readonly ILogger<LoginModel> _logger;
        [BindProperty] public AuthentificationView Authentification { get; set; } = new AuthentificationView();
        public LoginModel(IAuthentificationService authentication, IMapper mapper, ILogger<LoginModel> logger, IRegistrationService registrationService) =>
            (_authentication, _mapper, _logger) = (authentication, mapper, logger);

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Authentification == null) return Page();

            var userDTO = await _authentication.GetUserAsync(Authentification!.Login!,Authentification!.Password!);
            var user = _mapper.Map<UserView>(userDTO);

            if (user == null) return Page();

            await Authentificate(user!);

			_logger.LogCritical($"{userDTO!.IdUser} role: {userDTO.Role} {userDTO.GetType()}");
			_logger.LogCritical($"{user.IdUser} role: {user.Role} {user.GetType()}");

			return RedirectToPage("a");
        }

        private async System.Threading.Tasks.Task Authentificate(UserView user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.IdUser.ToString()),
				new Claim(ClaimTypes.Role, user.Role),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation("Авторизация выполнена");
            _logger.LogInformation($"defaultRoleClaimType: {user.Role}");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
