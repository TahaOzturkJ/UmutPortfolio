namespace Project.UI.Models
{
    public class TestimonialViewModel
    {
        public int TestimonialID { get; set; }
        public string ClientName { get; set; }
        public string CompanyName { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        public string Title { get; set; }
    }
}
