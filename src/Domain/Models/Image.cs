namespace Domain.Models
{
    public class Image
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public byte[] Value { get; set; }
        public ImageGroup ImageGroup { get; set; };
    }
}
