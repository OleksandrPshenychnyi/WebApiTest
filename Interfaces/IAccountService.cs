using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApi.Models;
using TestWebApi.ModelsDTO;

namespace TestWebApi.Interfaces
{
    public interface IAccountService
    {
        Account GetAccountForContact(ContactLinkToAccountDTO contactDTO);
        List<Account> GetAccountForIncident(IncidentCreationDTO incidentDTO);
        Task<Account> AccountCreationAsync(AccountCreationDTO accountDTO);
    }
}
