namespace WebApplication5.DTO
{
    public class ResponseStudentAddressDto
    {
        public int StudentId { get; set; }
        public int AddressId { get; set; }
        public string? State { get; set; }

        public string? City { get; set; }

        public string? PINCODE { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public long? PhoneNumber { get; set; }
    }
}
