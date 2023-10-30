using Models;
using Models.DTOs;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);

    Task<User?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}