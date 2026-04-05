using BlogApi.Models;
using MongoDB.Driver;

namespace BlogApi.Services
{
    public class BlogService
    {
        private readonly IMongoCollection<Blog> _blogs; // Blog, not BlogRepository

        public BlogService(IMongoClient client, IConfiguration config)
        {
            var db = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _blogs = db.GetCollection<Blog>("blogs");
        }

        public async Task<List<Blog>> GetBlogs() =>
            await _blogs.Find(_ => true).ToListAsync();

        public async Task<Blog?> GetBlog(string id) =>  // string not int
            await _blogs.Find(b => b.Id == id).FirstOrDefaultAsync();

        public async Task CreateBlog(Blog blog) =>
            await _blogs.InsertOneAsync(blog);

        public async Task DeleteBlog(string id) =>  // no need to fetch first
            await _blogs.DeleteOneAsync(b => b.Id == id);
    }
}