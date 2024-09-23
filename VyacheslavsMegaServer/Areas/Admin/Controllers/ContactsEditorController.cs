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
            ViewBag.SelectUserItems = _userManager.Users
                .OrderBy(u => u.UserName)
                .Select(u => new SelectListItem(u.UserName, u.Id));
            if (contactId == null)
                return View(new Contact());
            Contact selectedContact = await _contactsInfoRepository.GetContactById(contactId.Value);
            return View(selectedContact);
        }

        [HttpPost]
        public async Task<IActionResult> ContactDetails(Contact model)
        { 
            if (ModelState.IsValid)
            {
                await _contactsInfoRepository.SaveContact(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SelectUserItems = _userManager.Users
                .OrderBy(u => u.UserName)
                .Select(u => new SelectListItem(u.UserName, u.Id));
            return View(nameof(ContactDetails), model);
        }

        public async Task<IActionResult> ContactLinks(int contactId)
        {
            ViewBag.ContactId = contactId;
            LinksEditorViewModel model = new LinksEditorViewModel(await _contactsInfoRepository.GetContactLinks(contactId));
            return View(model);
        }

        public async Task<IActionResult> LinkDetails(int contactId, int? linkId, string? errorMessage) 
        {
            ViewBag.SelectContactItems = (await _contactsInfoRepository.GetAllContacts())
                .OrderBy(c => c.Id)
                .Select(c => new SelectListItem(c.DisplayName, c.Id.ToString()));
            if (!string.IsNullOrEmpty(errorMessage))
                ModelState.AddModelError(string.Empty, errorMessage);
            Link link;
            if (linkId == null)
            {
                link = new Link() { ContactId = contactId };
                return View(link);
            }
            link = await _contactsInfoRepository.GetLinkById(linkId.Value);
            return View(link);
        }

        [HttpPost]
        public async Task<IActionResult> LinkDetails(Link model)
        {
            if (ModelState.IsValid)
            {
                await _contactsInfoRepository.SaveLink(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SelectContactItems = (await _contactsInfoRepository.GetAllContacts())
                .OrderBy(c => c.Id)
                .Select(c => new SelectListItem(c.DisplayName, c.Id.ToString()));
            return View(model);
        }
    }
}
