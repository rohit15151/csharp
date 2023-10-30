using Models;
using Models.DTOs;

namespace HttpClients_.ClientInterfaces;

public interface IUserService
{ 
    Task<User> Create(UserCreationDto dto);
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);
    


}