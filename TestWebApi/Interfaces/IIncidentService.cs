using System.Threading.Tasks;
using TestWebApi.Models;
using TestWebApi.ModelsDTO;

namespace TestWebApi.Interfaces
{
    public interface IIncidentService
    {
        Task<Incident> IncidentCreationAsync(IncidentCreationDTO incidentDTO, Account account);
    }
}
