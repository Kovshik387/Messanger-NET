namespace MessangerWeb.Models
{
	public class RegisterView
	{
		public int IdUser { get; set; }

		public string Name { get; set; } = null!;

		public string Surname { get; set; } = null!;

		public string? Patronymic { get; set; }

		public string? Email { get; set; }

		public string Profileimage { get; set; } = "default_profile.jpg";

		public int IdAuthorize { get; set; }

		public string Login { get; set; } = null!;

		public string Password { get; set; } = null!;

		public string Type { get; set; } = null!;
	}
}
