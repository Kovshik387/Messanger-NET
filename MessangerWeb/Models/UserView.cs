namespace MessangerWeb.Models
{
	public class UserView
	{
		public int IdUser { get; set; } 

		public string Name { get; set; } = "unknown";

		public string Surname { get; set; } = "unknown";

		public string? Patronymic { get; set; } = null!;

		public string? Profileimage { get; set; } = "default";

		public string Role { get; set; } = null!;
	}
}
