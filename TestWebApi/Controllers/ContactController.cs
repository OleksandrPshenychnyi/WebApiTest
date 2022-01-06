using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestWebApi.Interfaces;
using TestWebApi.Models;
using TestWebApi.ModelsDTO;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ContactController : ControllerBase
    {

        readonly IAccountService accountService;    
        readonly IContactService contactService;
        public ContactController( IAccountService accServ, IContactService contServ)
        {
            accountService = accServ;
            contactService = contServ;
           
        }
       
       
        [HttpPost]
        public async Task<ActionResult<Contact>> Post(ContactLinkToAccountDTO contactDTO)
        {
 
            if (contactDTO == null)
            {
                return BadRequest("Empty input!");
            }
            var account = await accountService.GetAccountForContact( contactDTO);

            if (account == null)
            {
                return NotFound("No such account in database!");
            }
            var getContact = await contactService.ContactCreationAsync(contactDTO, account);
            
            return Ok(getContact);
        }
    }
}
