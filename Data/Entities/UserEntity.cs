namespace ForumWebApp.Data.Entities;

public class UserEntity
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Surname { get; set; }

    public int? Age { get; set; }

    public required DateTime CreateOn { get; set; }


    public IList<ChatEntity> CreatedChats { get; set; } = new List<ChatEntity>();

    public IList<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
}
