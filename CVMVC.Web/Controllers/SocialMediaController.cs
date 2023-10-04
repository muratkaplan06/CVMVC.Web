using System.Web.Mvc;
using CVMVC.Web.Models.Entity;
using CVMVC.Web.Repository;

namespace CVMVC.Web.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly SocialMediaRepository _db = new SocialMediaRepository();
        public ActionResult Index()
        {
            var result = _db.List();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            _db.Add(socialMedia);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var result = _db.Find(x => x.ID == id);
            return View(result);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var result = _db.Find(x => x.ID == socialMedia.ID);
            result.smname = socialMedia.smname;
            result.link = socialMedia.link;
            result.icon = socialMedia.icon;
            result.state = true;

            _db.Update(result);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var result = _db.Find(x => x.ID == id);
            result.state = false;
            _db.Update(result);
            return RedirectToAction("Index");
        }
    }
}