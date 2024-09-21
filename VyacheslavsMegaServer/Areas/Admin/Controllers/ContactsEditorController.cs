using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VyacheslavsMegaServer.Areas.Admin.Models;
using VyacheslavsMegaServer.Data.Entities;
using VyacheslavsMegaServer.Data.Repositories;

namespace VyacheslavsMegaServer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactsEditorController : Controller
    {
        private readonly ContactsInfoRepository _contactsInfoRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public ContactsEditorController(ContactsInfoRepository contactsInfoRepository, UserManager<IdentityUser> userManager)
        {
            _contactsInfoRepository = contactsInfoRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ContactsEditorViewModel model = new ContactsEditorViewModel(await _contactsInfoRepository.GetAllContacts());
            return View(model);
        }

        public async Task<IActionResult> ContactDetails(int? contactId) 
        {
            Contact selectedContact;
            ViewBag.SelectUserItems = _userManager.Users
                .OrderBy(u => u.UserName)
                .Select(u => new SelectListItem(u.UserName, u.Id));
            if (contactId == null)
            {
                return View();
            }
            selectedContact = await _contactsInfoRepository.GetContactById(contactId.Value);
            return View(selectedContact);
        }

        public async Task<IActionResult> SaveContact(Contact model)
        {
            if (ModelState.IsValid)
            {
                await _contactsInfoRepository.SaveContact(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> ContactLinks(int contactId)
        {
            LinksEditorViewModel model = new LinksEditorViewModel(await _contactsInfoRepository.GetContactLinks(contactId));
            return View(model);
        }
    }
}
