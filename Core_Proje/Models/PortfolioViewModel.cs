namespace Project.UI.Models
{
    public class PortfolioViewModel
    {
        public int PortfolioID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Image1 { get; set; }
        public string? ProjectUrl { get; set; }
        public int Condition { get; set; }
        public string Price { get; set; }
    }
}
