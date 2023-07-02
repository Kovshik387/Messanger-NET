using FluentValidation;
using MessangerWeb.Models;
using MessangerWeb.Pages.Account;

namespace MessangerWeb.Infrastructure.Validators
{
	public class AuthentificationModelValidator : AbstractValidator<AuthentificationView>
	{
		public AuthentificationModelValidator() 
		{
			this.RuleFor(l => l.Login).
				Length(3,20).
				NotEmpty().
				WithMessage("Введите логин");
			this.RuleFor(p => p.Password).
				Length(3,40).
				NotEmpty().
				WithMessage("Введите пароль");
		}
	}
}
