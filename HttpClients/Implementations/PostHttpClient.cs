using System.Net.Http.Json;
using System.Text.Json;
using Models;

namespace HttpClients_.Implementations;
using HttpClients_.ClientInterfaces;
using Models.DTOs;

    public class PostHttpClient : IPostService
    {
        private readonly HttpClient client;
    
        public PostHttpClient(HttpClient client)
        {
            this.client = client;
        }
    
        public async Task CreateAsync(PostCreationDto dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/posts",dto);
               if (!response.IsSuccessStatusCode)
               {
                   string content = await response.Content.ReadAsStringAsync();
                   throw new Exception(content);
               }
        }
        
        public async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"Posts/{id}");
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }
        
        public async Task<ICollection<Post>> GetAsync(User? username, string? title, string? body)
        {
            HttpResponseMessage response = await client.GetAsync("/posts");
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var statusCode = response.StatusCode;
                Console.WriteLine($"HTTP status code: {statusCode}");
                throw new Exception(content);
            }

            ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return posts;
        }
        
        public async Task<Post?> GetByIdAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"/posts/{id}");
            string content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                )!;
            }
            else
            {
                var statusCode = response.StatusCode;
                Console.WriteLine($"HTTP status code: {statusCode}");
                throw new HttpRequestException($"HTTP request failed with status code {(int)response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        
    }