using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Posts]")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        public int CategoryId { get; set; }
    }
}
