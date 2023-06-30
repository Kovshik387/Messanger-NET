using AutoMapper;
using BLL.Interfaces;
using MessangerWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessangerWeb.Pages.Account
{
    public class RegistrationModel : PageModel
    {
		//private readonly  _authentication;
		//private readonly IMapper _mapper;

		[BindProperty]
        public RegisterModel RegisterModel { get; set; } = null!;



/*        public Task<IActionResult> OnGetAsync()
        {
            return Task.FromResult(Page());
        }*/


    }
}
