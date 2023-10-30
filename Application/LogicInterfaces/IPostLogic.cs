namespace Models.DTOs;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAsync();
    Task<Post?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}