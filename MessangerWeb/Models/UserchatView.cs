namespace MessangerWeb.Models
{
	public class UserchatView
	{
		public int IdUchat { get; set; }

		public int IdUser { get; set; }

		public int IdChat { get; set; }

		public string ProfileImage { get; set; } = null!;

		public virtual ChatView IdChatNavigation { get; set; } = null!;

		public virtual UserView IdUserNavigation { get; set; } = null!;
	}
}
