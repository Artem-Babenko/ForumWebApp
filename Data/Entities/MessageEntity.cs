namespace ForumWebApp.Data.Entities;

public class MessageEntity
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public required DateTime CreateOn { get; set; }


    public required ChatEntity Chat { get; set; }

    public int ChatId { get; set; }

    public required UserEntity Author { get; set; }

    public int AuthorID { get; set; }
}
