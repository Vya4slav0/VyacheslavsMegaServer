using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using VyacheslavsMegaServer.Areas.Admin.Models;
using VyacheslavsMegaServer.Data.Entities;
using VyacheslavsMegaServer.Data.Repositories;

namespace VyacheslavsMegaServer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PartnersEditorController : Controller
    {
        private readonly PartnersInfoRepository _partnersInfoRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PartnersEditorController(PartnersInfoRepository partnersInfoRepository, IWebHostEnvironment hostEnvironment)
        {
            _partnersInfoRepository = partnersInfoRepository;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            PartnersEditorViewModel model = new PartnersEditorViewModel(await _partnersInfoRepository.GetAllPartners());
            return View(model);
        }

        public async Task<IActionResult> PartnerDetails(int? partnerId) 
        {
            if (partnerId == null)
                return View(new Partner());
            return View(await _partnersInfoRepository.GetPartnerById(partnerId.Value));
        }

        [HttpPost]
        public async Task<IActionResult> PartnerDetails(Partner model, IFormFile? partnerLogoImage)
        {
            if (!ModelState.IsValid) return View(model);

            string uniqueFileName = string.Empty;
            if (partnerLogoImage != null) 
            {
                string uploaderFileName = partnerLogoImage.FileName.ToLower();
                uniqueFileName = string.Concat(
                    Guid.NewGuid(),
                    uploaderFileName.Substring(uploaderFileName.LastIndexOf('.')));
                using (FileStream imageStream = new FileStream(
                    Path.Combine(_hostEnvironment.WebRootPath, "img", "partners", uniqueFileName), 
                    FileMode.Create))
                {
                    await partnerLogoImage.CopyToAsync(imageStream);
                }
                new FileInfo(Path.Combine(_hostEnvironment.WebRootPath, "img", "partners", model.LogoFileName)).Delete();
                model.LogoFileName = uniqueFileName;
            }
            await _partnersInfoRepository.SavePartner(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemovePartner(int partnerId)
        {
            Partner partnerToRemove = await _partnersInfoRepository.GetPartnerById(partnerId);
            await _partnersInfoRepository.RemovePartnerById(partnerId);
            new FileInfo(Path.Combine(_hostEnvironment.WebRootPath, "img", "partners", partnerToRemove.LogoFileName)).Delete();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PartnerLinks(int partnerId)
        {
            ViewBag.PartnerId = partnerId;
            LinksEditorViewModel<PartnerLink> model = new LinksEditorViewModel<PartnerLink>(await _partnersInfoRepository.GetPartnerLinks(partnerId));
            return View(model);
        }

        public async Task<IActionResult> LinkDetails(int partnerId, int? linkId)
        {
            ViewBag.SelectPartnerItems = (await _partnersInfoRepository.GetAllPartners())
                .OrderBy(p => p.Id)
                .Select(p => new SelectListItem(p.Name, p.Id.ToString()));
            ViewBag.PartnerId = partnerId;
            PartnerLink link;
            if (linkId == null)
            {
                link = new PartnerLink() { PartnerId = partnerId };
                return View(link);
            }
            link = await _partnersInfoRepository.GetLinkById(linkId.Value);
            return View(link);
        }

        [HttpPost]
        public async Task<IActionResult> LinkDetails(PartnerLink model, int partnerId)
        {
            if (ModelState.IsValid)
            {
                await _partnersInfoRepository.SaveLink(model);
                RouteValueDictionary routeValues = new RouteValueDictionary()
                {
                    { "partnerId", partnerId }
                };
                return RedirectToAction(nameof(PartnerLinks), routeValues);
            }
            ViewBag.SelectPartnerItems = (await _partnersInfoRepository.GetAllPartners())
                .OrderBy(p => p.Id)
                .Select(p => new SelectListItem(p.Name, p.Id.ToString()));
            return View(model);
        }

        public async Task<IActionResult> RemoveLink(int linkId, int partnerId)
        {
            await _partnersInfoRepository.RemoveLinkById(linkId);
            RouteValueDictionary routeValues = new RouteValueDictionary()
            {
                { "contactId", partnerId }
            };
            return RedirectToAction(nameof(PartnerLinks), routeValues);
        }
    }
}
