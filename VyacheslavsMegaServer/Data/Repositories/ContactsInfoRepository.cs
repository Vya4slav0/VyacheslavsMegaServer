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

        public async Task<List<ContactLink>> GetContactLinks(int contactId)
        {
            return await _db.ContactLinks.Where(l => l.ContactId == contactId).ToListAsync() ?? new List<ContactLink>();
        }

        public async Task<ContactLink> GetLinkById(int linkId)
        {
            return await _db.ContactLinks.FirstAsync(l => l.Id == linkId);
        }

        public async Task SaveLink(ContactLink link)
        {
            if (link.Id == 0)
                _db.Entry(link).State = EntityState.Added;
            else
                _db.Entry(link).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }

        public async Task RemoveContactById(int id)
        {
            _db.Remove(new Contact() { Id = id });
            await _db.SaveChangesAsync();
        }

        public async Task RemoveLinkById(int id)
        {
            _db.Remove(new ContactLink() { Id = id });
            await _db.SaveChangesAsync();
        }
    }
}
