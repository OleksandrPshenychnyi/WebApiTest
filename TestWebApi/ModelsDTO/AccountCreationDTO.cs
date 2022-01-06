using System.Collections.Generic;

namespace TestWebApi.ModelsDTO
{
    public class AccountCreationDTO
    {
        
        public string AccountName { get; set; }
        public List<ContactsCreationDTO> Contacts { get; set; }
       
    }
}
