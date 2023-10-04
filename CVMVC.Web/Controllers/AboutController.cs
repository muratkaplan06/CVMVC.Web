using System.Web.Mvc;
using CVMVC.Web.Models.Entity;
using CVMVC.Web.Repository;

namespace CVMVC.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly AboutRepository _db = new AboutRepository();
        public ActionResult Index()
        {
            var result = _db.List();
            return View(result);
        }
        [HttpPost]
        public ActionResult Index(About about)
        {
            var result = _db.Find(x => x.ID == 1);
            result.firstname = about.firstname;
            result.lastname = about.lastname;
            result.address = about.address;
            result.phonenumber = about.phonenumber;
            result.mail = about.mail;
            result.description = about.description;
            result.image = about.image;

            _db.Update(result);

            TempData["SuccessMessage"] = "update successful.";
            return RedirectToAction("Index");
        }
    }
}