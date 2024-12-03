namespace WebApplication5.Models
{
        public class StudentAddress
        {
            public int Id { get; set; } 
            public required string State { get; set; }

            public string? City { get; set; }

            public string? PINCODE { get; set; }

            // Navigation property to StudentModel table


            public StudentModel? Student { get; set; }
        }

}

