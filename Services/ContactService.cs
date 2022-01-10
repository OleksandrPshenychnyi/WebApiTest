using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task ContactCreationForIncidentAsync(IncidentCreationDTO incidentDTO, List<Account> account)
        {
            var accInfo = incidentDTO.AccContInfo;
            var accountIncidentInfo = accInfo.Zip(account, (s, m) => new {  AccountNameInfo = s, AccountObject = m });
            foreach (var sm in accountIncidentInfo)
            {
                var contact = await db.Contacts.FindAsync(sm.AccountNameInfo.ContactEmail);
                if (contact != null)
                {
                    contact.FirstName = sm.AccountNameInfo.ContactFirstName;
                    contact.LastName = sm.AccountNameInfo.ContactLastName;
                    contact.Account = sm.AccountObject;
                    db.Contacts.Update(contact);
                }
                else
                {
                    Contact contactToCreate = new Contact()
                    {
                        FirstName = sm.AccountNameInfo.ContactFirstName,
                        LastName = sm.AccountNameInfo.ContactLastName,
                        Email = sm.AccountNameInfo.ContactEmail,
                        Account = sm.AccountObject
                    };
                    db.Contacts.Add(contactToCreate);
                }
            }
            
            await db.SaveChangesAsync();
        }
    }
}
