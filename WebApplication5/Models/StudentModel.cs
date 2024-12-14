using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication5.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public long? PhoneNumber { get; set; }


        //Foreign Key
        public int? AddressId { get; set; }
        public int? ImageId { get; set; }


        // Navigation property
        public StudentAddress?  Address { get; set; }  
        public Image? Image { get; set; }

    }

}

