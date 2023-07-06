namespace MessangerWeb.Models
{
	public class ChatView
	{
		public int IdChat { get; set; }
		public virtual IList<MessageView> Messages { get; set; } = new List<MessageView>();
		public virtual IList<UserchatView> Userschats { get; set; } = new List<UserchatView>();
	}
}
