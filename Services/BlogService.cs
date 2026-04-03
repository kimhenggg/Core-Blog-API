using BlogApi.Data;
using BlogApi.Models;

namespace BlogApi.Services
{
    public class BlogService
    {
        private readonly BlogRepository _repo;

        public BlogService() // method
        {
            _repo = new BlogRepository();
        }

        public List<Blog> GetBlogs()
        {
            return _repo.GetAll();
        }

        public Blog GetBlog(int id)
        {
            return _repo.GetById(id);
        }

        public void CreateBlog(Blog blog)
        {
            _repo.Add(blog);
        }

        public void DeleteBlog(int id)
        {
            var blog = _repo.GetById(id);
            if (blog !=null)
            {
                _repo.Delete(blog);
            }
        }
    }
}

