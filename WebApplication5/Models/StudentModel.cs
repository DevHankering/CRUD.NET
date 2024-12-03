using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication5.Models
{
    public class StudentModel
    {
            public int Id { get; set; }
            public required string FirstName { get; set; }
            public required string LastName { get; set; }
            public required string Email { get; set; }
            public long? PhoneNumber { get; set; }



        // Foreign key to StudentAddress table
        public int? Address_Id { get; set; }

        // Navigati
        // on property to StudentAddress table
        [JsonIgnore]
        public StudentAddress? Address { get; set; }
        }

    }

