using BlogApi.Models;

namespace BlogApi.Data
{
    public class BlogRepository
    {
        private static List<Blog> blogs = new List<Blog>();

        public List<Blog> GetAll()
        {
            return blogs;
        }

        public Blog GetById(int id)
        {
            return blogs.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Blog blog)
        {
            if (blogs.Count == 0)
                blog.Id = 1;
            else
                blog.Id = blogs.Max(b => b.Id) + 1;

            blogs.Add(blog);
        }

        public void Delete(Blog blog)
        {
            blogs.Remove(blog);
        }
    }
}

