namespace BlazorTest.Models
{
    public class Comment
    {
        public int PostId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}
