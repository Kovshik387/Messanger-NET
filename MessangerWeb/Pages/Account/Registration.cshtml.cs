using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using MessangerWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MessangerWeb.Pages.Account
{
    public class RegistrationModel : PageModel
    {
		private readonly IRegistrationService _registration;
		private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger _logger;
		
        [BindProperty]
        public RegisterView RegisterModel { get; set; } = null!;
        
        [BindProperty (SupportsGet = true)]
        public IFormFile? Upload { get; set; } = null!;

        [BindProperty]
        public List<RoleView> RoleSelecter { get; set; } = new List<RoleView> ();

        public RegistrationModel(IWebHostEnvironment webHostEnvironment, 
            IRegistrationService registration, IMapper mapper, ILogger<RegistrationModel> logger) 
        {
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            _logger = logger;
            _registration = registration;

        }

        public async Task OnGet()
        {
            RoleSelecter = _mapper.Map<List<RoleView>>(await _registration.GetAllRoleAsync());

            foreach (var item in RoleSelecter) _logger.LogWarning($"{item.IdRole} {item.Type}");
        }

        public async Task<IActionResult> OnPostAsync()
        {
			RoleSelecter = _mapper.Map<List<RoleView>>(await _registration.GetAllRoleAsync());
			if (!ModelState.IsValid) return Page();

            if (Upload != null)
            {
                string path = "/Pictures/" + Guid.NewGuid().ToString() + ".png";
                using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }

                RegisterModel.Profileimage = path;
            }
            else RegisterModel.Profileimage = "/Pictures/default_profile.jpg";

			var registerDTO = _mapper.Map<RegisterDTO>(RegisterModel);

			await _registration.AddUserAsync(registerDTO);

            _logger.LogInformation("Зарегестрирован");

			return RedirectToPage("/Index");
        }


    }
}
