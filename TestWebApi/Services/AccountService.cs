using AutoMapper;
using System;
using System.Threading.Tasks;
using TestWebApi.Interfaces;
using TestWebApi.Models;
using TestWebApi.ModelsDTO;

namespace TestWebApi.Services
{
    public class AccountService : IAccountService
    {

        readonly ProgContext db;
        readonly IMapper _mapper;
        public AccountService(ProgContext progContext, IMapper mapper)
        {
            db = progContext;
            _mapper = mapper;
        }
        public async Task<Account> GetAccountForContact(ContactLinkToAccountDTO contactDTO)
        {
            var account = await db.Accounts.FindAsync(contactDTO.AccountName);
            return account;
        }
        public async Task<Account> AccountCreationAsync(AccountCreationDTO accountDTO)
        {
            var mappedAccount = _mapper.Map<Account>(accountDTO);
            //Account account = new Account()
            //{
            //    AccountName = accountDTO.AccountName

            //};
            try
            {
                db.Accounts.Add(mappedAccount);
                // await db.SaveChangesAsync(); 
                //List<Contact> contacts = new List<Contact>();
                //foreach (var contact in accountDTO.Contacts)
                //{
                //    contacts.Add(new Contact()
                //    {
                //        Email = contact.Email,
                //        FirstName = contact.FirstName,
                //        LastName = contact.LastName,
                //        Account = mappedAccount
                //    });
                //}
                db.Contacts.AddRange(mappedAccount.Contacts);
                await db.SaveChangesAsync();
                return mappedAccount;
            }
            catch
            {
                throw new Exception("Account name and contact emails must be unique!");
            }
        }
        public async Task<Account> GetAccountForIncident(IncidentCreationDTO incidentDTO)
        {
            var account = await db.Accounts.FindAsync(incidentDTO.AccountName);
            return account;
        }
    }
}
