using System.ComponentModel.DataAnnotations;

namespace TestWebApi.ModelsDTO
{
    public class ContactsCreationDTO
    {
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
