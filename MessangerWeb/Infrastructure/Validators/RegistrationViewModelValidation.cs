using FluentValidation;
using MessangerWeb.Models;

namespace MessangerWeb.Infrastructure.Validators
{
	public class RegistrationViewModelValidation : AbstractValidator<RegisterView>
	{
		public RegistrationViewModelValidation()
		{
			this.RuleFor(name => name.Name).Length(3,40).NotEmpty().WithMessage("Введите имя");
			this.RuleFor(surname => surname.Surname).Length(3, 40).NotEmpty().WithMessage("Введите фамилию");
			this.RuleFor(patronymic => patronymic.Patronymic).Length(0, 40).WithMessage("Введите имя");
			this.RuleFor(login => login.Login).Length(3, 40).NotEmpty().WithMessage("Введите имя");
			this.RuleFor(password => password.Password).Length(3,40).WithMessage("Введите пароль");
			this.RuleFor(email => email.Email).Length(3,60);
		}
	}
}
