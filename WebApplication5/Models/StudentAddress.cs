using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
        public class StudentAddress
        {
        [Key]
        public int AddressId { get; set; }
        public string? State { get; set; }

        public string? City { get; set; }

        public string? PINCODE { get; set; }
        
         }

}

