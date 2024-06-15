namespace BlazorTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Category { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
