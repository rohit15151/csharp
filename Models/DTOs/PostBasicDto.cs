namespace Models.DTOs;

public class PostBasicDto
{
    public int Id { get; }
    public string OwnerName { get; }
    public string Title { get; }
    public string Body { get; }

    public PostBasicDto(int id, string ownerName, string title, string body)
    {
        Id = Id;
        OwnerName = ownerName;
        Title = title;
        Body = body;
    }
    
    public PostBasicDto(int id, string title)
    {
        Id = Id;
        Title = title;

    }
    
}