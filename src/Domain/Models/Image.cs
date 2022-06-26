namespace Domain.Models
{
    public class Image
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Url { get; set; }
        public ImageResolution Resolution { get; set; }
        public string GroupId { get; set; }
        public ImageGroup Group { get; set; }
    }
}
