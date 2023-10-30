using Application.DaoInterfaces;
using Models;
using Models.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.OwnerId);
        if (user == null)
        {
            throw new Exception($"User with id {dto.OwnerId} was not found.");
        }

        ValidatePost(dto);
        Post post = new Post(user, dto.Title, dto.Body);
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        return await postDao.GetAsync();
    }

    private void ValidatePost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        // other validation stuff
    }
    
    public async Task DeleteAsync(int id)
    {
        Post? post = await postDao.GetByIdAsync(id);
        if (post == null)
        {
            throw new Exception($"Todo with ID {id} was not found!");
        }

        if (!post.IsPrivate)
        {
            throw new Exception("Cannot delete un-completed Todo!");
        }

        await postDao.DeleteAsync(id);
    }

    public Task<Post> GetByIdAsync(int id)
    {
        return postDao.GetByIdAsync(id);
    }
}