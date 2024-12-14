namespace WebApplication5.DTO
{
    public class ImageUploadRequestDto
    {
        public required IFormFile File  { get; set; }
        public required string FileName { get; set; }
        public string? FileDescription  { get; set; }

    }
}
