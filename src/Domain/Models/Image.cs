namespace Domain.Models
{
    public class Image
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Url { get; set; }
        public ImageResolution ImageResolution { get; set; }
        public string ImageGroupId { get; set; }
        public ImageGroup ImageGroup { get; set; }
    }
}
