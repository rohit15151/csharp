namespace Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; }
    public string Title { get; }
    public string Body { get; }
    public bool IsPrivate { get; set; }

    public Post(User owner, string title, string body)
    {
        Owner = owner;
        Body = body;
        Title = title;
    }
    
}