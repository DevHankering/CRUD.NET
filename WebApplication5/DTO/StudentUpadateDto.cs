﻿namespace WebApplication5.DTO
{
    public class StudentUpadateDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public long? PhoneNumber { get; set; }
        public int? Address_Id { get; set; }


    }
}
