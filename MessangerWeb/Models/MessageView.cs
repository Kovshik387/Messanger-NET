namespace MessangerWeb.Models
{
	public class MessageView
	{
		public int IdMess { get; set; }

		public DateTime Datesend { get; set; }

		public string Body { get; set; } = null!;

		public bool Isread { get; set; }

		public int IdUser { get; set; }
		public int IdChat { get; set; }

        public virtual UserView IdUserNavigation { get; set; } = null!;
	}
}
