using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApi.Interfaces;
using TestWebApi.Models;
using TestWebApi.ModelsDTO;

namespace TestWebApi.Services
{
    public class IncidentService : IIncidentService
    {
        readonly ProgContext db;
        readonly IMapper _mapper;
        public IncidentService(ProgContext progContext, IMapper mapper)
        {
            db = progContext;
            _mapper = mapper;
        }
        public async Task<Incident> IncidentCreationAsync(IncidentCreationDTO incidentDTO, List<Account> account)
        {
            var mappedIncident = _mapper.Map<Incident>(incidentDTO);
            foreach (var acc in account)
            {
                acc.Incident = mappedIncident;
            }
            db.Incident.Add(mappedIncident);
            await db.SaveChangesAsync();
            return mappedIncident;
        }
    }
}
