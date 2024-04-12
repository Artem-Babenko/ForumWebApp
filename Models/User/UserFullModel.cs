namespace ForumWebApp.Models;

public class UserFullModel
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Surname { get; set; }

    public int Age { get; set; }

    public DateTime CreateOn { get; set; }
}
