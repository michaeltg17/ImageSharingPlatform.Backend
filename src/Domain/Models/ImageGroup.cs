namespace Domain.Models
{
    public class ImageGroup
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public List<Image> Images { get; set; } = new List<Image>();
    }
}
