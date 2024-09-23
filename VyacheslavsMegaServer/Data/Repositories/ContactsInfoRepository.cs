using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using VyacheslavsMegaServer.Data.Entities;

namespace VyacheslavsMegaServer.Data.Repositories
{
    public class ContactsInfoRepository
    {
        private readonly AppDbContext _db;

        public ContactsInfoRepository() 
        {
            _db = new AppDbContext();
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _db.Contacts.ToListAsync() ?? new List<Contact>();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _db.Contacts.FirstAsync(c => c.Id == id);
        }

        public async Task SaveContact(Contact contact)
        {
            if (contact.Id == 0) 
                _db.Entry(contact).State = EntityState.Added;
            else
                _db.Entry(contact).State = EntityState.Modified;
            
            await _db.SaveChangesAsync();
        }

        public async Task<List<Link>> GetContactLinks(int contactId)
        {
            return await _db.Links.Where(l => l.ContactId == contactId).ToListAsync() ?? new List<Link>();
        }

        public async Task<Link> GetLinkById(int linkId)
        {
            return await _db.Links.FirstAsync(l => l.Id == linkId);
        }

        public async Task SaveLink(Link link)
        {
            if (link.Id == 0)
                _db.Entry(link).State = EntityState.Added;
            else
                _db.Entry(link).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }
    }
}
