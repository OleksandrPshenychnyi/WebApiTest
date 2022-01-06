using System.Threading.Tasks;
using TestWebApi.Models;
using TestWebApi.ModelsDTO;

namespace TestWebApi.Interfaces
{
    public interface IAccountService
    {
        Task<Account> GetAccountForContact(ContactLinkToAccountDTO contactDTO);
        Task<Account> GetAccountForIncident(IncidentCreationDTO incidentDTO);
        Task<Account> AccountCreationAsync(AccountCreationDTO accountDTO);
    }
}
