using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestWebApi.Models
{
    public class Incident
    {
        [Key]
        public string IncidentName { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<Account> Accounts { get; set; }
        
       
       
    }
}
