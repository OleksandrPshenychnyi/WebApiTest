using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Account GetAccountForContact(ContactLinkToAccountDTO contactDTO)
        {
            var account = db.Accounts.Where(p=> p.AccountName == contactDTO.AccountName).FirstOrDefault();
            return account;
        }
        public async Task<Account> AccountCreationAsync(AccountCreationDTO accountDTO)
        {
            var mappedAccount = _mapper.Map<Account>(accountDTO);
            try
            {
                db.Accounts.Add(mappedAccount);
                db.Contacts.AddRange(mappedAccount.Contacts);
                await db.SaveChangesAsync();
                return mappedAccount;
            }
            catch
            {
                throw new Exception("Account name and contact emails must be unique!");
            }
        }
        public List<Account> GetAccountForIncident(IncidentCreationDTO incidentDTO)
        {
 
            List<Account> accounts = new List<Account>();
            foreach (var item in incidentDTO.AccContInfo)
            {
                var account =  db.Accounts.Where(p => p.AccountName == item.AccountName).FirstOrDefault();
                accounts.Add(account);
            }
            
            return accounts;
        }
    }
}
