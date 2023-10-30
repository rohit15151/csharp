using Models;
using Application.Logic;
using Models.DTOs;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    public Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync();
    Task DeleteAsync(int id);
    Task<Post?> GetByIdAsync(int id);
}