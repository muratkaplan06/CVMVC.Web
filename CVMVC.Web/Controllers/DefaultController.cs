using System;
using System.Linq;
using System.Web.Mvc;
using CVMVC.Web.Models.Entity;

namespace CVMVC.Web.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly DbCvEntities _db = new DbCvEntities();
        // GET: Default
        public ActionResult Index()
        {
            var result = _db.About.ToList();
            return View(result);
        }

        public PartialViewResult Experience()
        {
            var result = _db.Experiences.ToList();
            return PartialView(result);
        }

        public PartialViewResult Educations()
        {
            var result = _db.Educations.ToList();
            return PartialView(result);
        }

        public PartialViewResult Skills()
        {
            var result = _db.Skills.ToList();
            return PartialView(result);
        }

        public PartialViewResult Hobbies()
        {
            var result = _db.Hobbies.ToList();
            return PartialView(result);
        }

        public PartialViewResult Awards()
        {
            var result = _db.Certificates.ToList();
            return PartialView(result);
        }
        [HttpGet]
        public PartialViewResult Communication()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Communication(Communications com)
        {
            var today = DateTime.Today;
            var userEmail = com.mail;

            var messageCount = _db.Communications
                .Where(c => c.date == today && c.mail == userEmail)
                .Count();

            if (!ModelState.IsValid)
            {
                return PartialView(com);
            }

            if (messageCount >= 3)
            {
                ViewBag.Error = "invalid Attempt";
                return PartialView(com);
            }

            com.date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _db.Communications.Add(com);
            _db.SaveChanges();
            ModelState.Clear();
            return PartialView();
        }
        public PartialViewResult SocialMedia()
        {
            var result = _db.SocialMedia.Where(x=>x.state==true).ToList();
            return PartialView(result);
        }
    }
}