namespace DAL.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!; 

    public string? Patronymic { get; set; }

    public string? Email { get; set; }

    public DateOnly Datestartwork { get; set; }

    public DateOnly? Dateendwork { get; set; }

    public bool Active { get; set; }

    public string? Profileimage { get; set; }

    public int IdAuthorize { get; set; }

    public virtual ICollection<Chat> ChatIdUseroneNavigations { get; set; } = new List<Chat>();

    public virtual ICollection<Chat> ChatIdUsertwoNavigations { get; set; } = new List<Chat>();

    public virtual Authorize IdAuthorizeNavigation { get; set; } = null!;

    public virtual Message? MessageUserfromNavigation { get; set; }

    public virtual Message? MessageUsertoNavigation { get; set; }
}
