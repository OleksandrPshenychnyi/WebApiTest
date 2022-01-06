using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models
{
    public class Account
    {
        [Key]
        [Required]
        public string AccountName { get; set; }
        public List<Contact> Contacts { get; set; }
        public Incident Incident { get; set; }
    }
}
