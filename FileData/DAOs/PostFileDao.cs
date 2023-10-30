using System.Text.Json;
using Application.DaoInterfaces;
using Models;
using Models.DTOs;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.Id);
            id++;
        }

        post.Id = id;

        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync()
    {
        IEnumerable<Post> result = context.Posts.AsEnumerable();
        
        return Task.FromResult(result);
    }

    public Task DeleteAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(post => post.Id == id);
        if (existing == null)
        {
            throw new Exception($"Post with id {id} does not exist!");
        }

        context.Posts.Remove(existing);
        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(existing);
    }
}