namespace WebApplication5.DTO
{
    public class StudentAddressImageDto
    {
        //Student
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public long? PhoneNumber { get; set; }
        //Address
        public string? State { get; set; }

        public string? City { get; set; }

        public string? PINCODE { get; set; }

        //ImageFile
        //public IFormFile? File { get; set; }
        public string? FileName { get; set; }
        public string? FileDescription { get; set; }
        public string? FileExtension { get; set; }
        public long? FileSizeInBytes { get; set; }
        public string? FilePath { get; set; }
    }
}
