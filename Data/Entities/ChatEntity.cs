namespace ForumWebApp.Data.Entities;

public class ChatEntity
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public required DateTime CreateOn { get; set; }


    public required IList<MessageEntity> Messages { get; set; }

    public required UserEntity Author { get; set; }

    public int AuthorId { get; set; }
}
