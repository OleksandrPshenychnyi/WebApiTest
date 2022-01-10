using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestWebApi.Interfaces;
using TestWebApi.Models;
using TestWebApi.ModelsDTO;

namespace TestWebApi.Services
{
    public class ContactService : IContactService
    {
        readonly ProgContext db;
        readonly IMapper _mapper;
        public ContactService(ProgContext progContext, IMapper mapper)
        {
            db = progContext;
            _mapper = mapper;
        }
        public async Task<Contact> ContactCreationAsync(ContactLinkToAccountDTO contactDTO, Account account )
        {
            
            var mappedContact = _mapper.Map<Contact>(contactDTO);
            mappedContact.Account = account;
            db.Contacts.Add(mappedContact);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new("Email is already exist!", ex);

            }
            return mappedContact;
        }

        public async Task ContactCreationForIncidentAsync(IncidentCreationDTO incidentDTO, Account account)
        {
            var contact = await db.Contacts.FindAsync(incidentDTO.ContactEmail);
            if (contact != null)
            {
                contact.FirstName = incidentDTO.ContactFirstName;
                contact.LastName = incidentDTO.ContactLastName;
                contact.Account = account;
                db.Contacts.Update(contact);
            }
            else
            {
                Contact contactToCreate = new Contact()
                {
                    FirstName = incidentDTO.ContactFirstName,
                    LastName = incidentDTO.ContactLastName,
                    Email = incidentDTO.ContactEmail,
                    Account = account
                };
                db.Contacts.Add(contactToCreate);
            }
            await db.SaveChangesAsync();
        }
    }
}
