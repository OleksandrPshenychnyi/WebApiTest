using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestWebApi.Models;

namespace TestWebApi.ModelsDTO
{
    public class IncidentCreationDTO
    {
        
        public string Description { get; set; }
        public List<AccountContactInfoDTO> AccContInfo { get; set; }
        //public string AccountName { get; set; }
        //public string ContactFirstName { get; set; }
        //public string ContactLastName { get; set; }
        //[EmailAddress(ErrorMessage = "Not a valid email")]
        //public string ContactEmail { get; set; }

    }
}
