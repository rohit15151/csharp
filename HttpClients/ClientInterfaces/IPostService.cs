using Models;

namespace HttpClients_.ClientInterfaces;
using Models.DTOs;

public interface IPostService
 {
     Task CreateAsync(PostCreationDto dto);

     Task<ICollection<Post>> GetAsync(User? username, string title, string?body); 
     
     Task<Post?> GetByIdAsync(int id);
     Task DeleteAsync(int id);
 }