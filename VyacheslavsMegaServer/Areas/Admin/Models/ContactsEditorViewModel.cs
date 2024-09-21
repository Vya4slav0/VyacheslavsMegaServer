using Microsoft.AspNetCore.Mvc;
using VyacheslavsMegaServer.Data.Entities;

namespace VyacheslavsMegaServer.Areas.Admin.Models
{
    [Area("Admin")]
    public class ContactsEditorViewModel
    {
        List<Contact> _contacts;

        public ContactsEditorViewModel(List<Contact> contacts) 
        { 
            _contacts = contacts;
        }

        public List<Contact> Contacts => _contacts;
    }
}
