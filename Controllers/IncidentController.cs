using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestWebApi.Interfaces;
using TestWebApi.Models;
using TestWebApi.ModelsDTO;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        readonly IAccountService accountService;
        readonly IIncidentService incidentService;
        readonly IContactService contactService;
        public IncidentController( IAccountService accServ, IIncidentService incServ, IContactService contServ)
        {
         
            accountService = accServ;
            incidentService = incServ;
            contactService = contServ;
         
        }
       
        
        [HttpPost]
        public async Task<ActionResult<Incident>> Post(IncidentCreationDTO incidentDTO)
        {
            if (incidentDTO == null)
            {
                return BadRequest("Empty input!");
            }
            var account =  accountService.GetAccountForIncident(incidentDTO);

            foreach (var acc in account)
            {
                if (acc == null)
                {
                    return NotFound("No such account in database!");
                }
            }
            
            await contactService.ContactCreationForIncidentAsync(incidentDTO, account);
            
            var incident = await incidentService.IncidentCreationAsync(incidentDTO, account);
            
            return Ok(incident);
        }
    }
}
