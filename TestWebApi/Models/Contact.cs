using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestWebApi.Models
{
    public class Contact
    {
        [Key]
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
    }
}
