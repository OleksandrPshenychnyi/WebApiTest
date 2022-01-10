using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.ModelsDTO
{
    public class AccountContactInfoDTO
    {
        public string AccountName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string ContactEmail { get; set; }
    }
}
