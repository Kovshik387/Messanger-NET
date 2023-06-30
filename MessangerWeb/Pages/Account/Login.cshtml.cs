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
        private readonly IRegistrationService _registration;
        private readonly IMapper _mapper;
        private readonly ILogger<LoginModel> _logger;
        [BindProperty] public AuthentificationModel Authentification { get; set; } = new AuthentificationModel();
        public LoginModel(IAuthentificationService authentication, IMapper mapper, ILogger<LoginModel> logger, IRegistrationService registrationService) =>
            (_authentication, _mapper, _logger,_registration) = (authentication, mapper, logger,registrationService);

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Authentification == null) return Page();

            var userDTO = await _authentication.GetUserAsync(Authentification!.Login!,Authentification!.Password!);
            var user = _mapper.Map<UserModel>(userDTO);

            if (user == null) return Page();

            await Authentificate(user!);

			_logger.LogCritical($"{userDTO!.IdUser} role: {userDTO.Role} {userDTO.GetType()}");
			_logger.LogCritical($"{user.IdUser} role: {user.Role} {user.GetType()}");

            //


            var registrationTest = new RegisterModel()
            {
                Email = "test",
                Login = "lox",
                Password = "test",
                Name = "test",
                Profileimage = "test",
                Patronymic = "test",
                Surname = "test",
                Type = "Работник",
            };
            var registerDTO = _mapper.Map<RegisterDTO>(registrationTest);

            await _registration.AddUserAsync(registerDTO);

            //

			return RedirectToPage("Privacy");
        }

        private async System.Threading.Tasks.Task Authentificate(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.IdUser.ToString()),
				new Claim(ClaimTypes.Role, user.Role),
				//new Claim("Role", ),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation("Авторизация выполнена");
            _logger.LogInformation($"defaultRoleClaimType: {user.Role}");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
