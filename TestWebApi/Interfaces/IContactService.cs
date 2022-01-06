using System.Threading.Tasks;
using TestWebApi.Models;
using TestWebApi.ModelsDTO;

namespace TestWebApi.Interfaces
{
    public interface IContactService
    {
        Task<Contact> ContactCreationAsync(ContactLinkToAccountDTO contactDTO, Account account);
        Task ContactCreationForIncidentAsync(IncidentCreationDTO incidentDTO, Account account);
    }
}
