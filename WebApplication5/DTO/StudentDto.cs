using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.DTO
{
    public class StudentDto
    {
        public string? FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public long? PhoneNumber { get; set; }
        public int? Address_Id { get; set; }
        //public required string ImageFileName { get; set; }
        public IFormFile? ImageFile { get; set; }
        //[NotMapped]
        public string? ImageFileName { get; set; }


    }
}
