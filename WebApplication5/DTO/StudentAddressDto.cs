﻿namespace WebApplication5.DTO
{
    public class StudentAddressDto
    {
        //address
       
        public int StudentId { get; set; }
        public string? State { get; set; }

        public string? City { get; set; }

        public string? PINCODE { get; set; }


        //student

        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public long? PhoneNumber { get; set; }

        //public AddressDto? Address { get; set; }

    }

    //public class AddressDto : StudentAddressDto
    //{
        //public string? State { get; set; }

        //public string? City { get; set; }

        //public string? PINCODE { get; set; }
    //}


}
