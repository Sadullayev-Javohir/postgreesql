namespace Lazy.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }

        // ⚠️ Lazy loading uchun virtual
        public virtual User User { get; set; }
    }
}
