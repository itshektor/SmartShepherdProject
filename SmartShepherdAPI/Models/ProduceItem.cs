namespace SmartShepherdAPI.Models
{
    public class ProduceItem
    {
        public int Id { get; set; } // Required for matching and identification
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
