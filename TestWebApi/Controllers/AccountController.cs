using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestWebApi.Interfaces;
using TestWebApi.Models;
using TestWebApi.ModelsDTO;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IAccountService accountService;
        public AccountController( IAccountService accServ)
        {
          
            accountService = accServ;
           
        }

        [HttpPost]
        public async Task<ActionResult<Account>> Post(AccountCreationDTO accountDTO)
        {
           
            if (accountDTO == null)
            {
                return BadRequest();
            }
            
            if (accountDTO.Contacts == null)
            {
                return BadRequest();
            }

            var createAccount = await accountService.AccountCreationAsync(accountDTO);
            return Ok(createAccount);
        }
    }
}
