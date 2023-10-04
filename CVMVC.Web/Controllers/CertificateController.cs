using System.Web.Mvc;
using CVMVC.Web.Models.Entity;
using CVMVC.Web.Repository;

namespace CVMVC.Web.Controllers
{
    public class CertificateController : Controller
    {
        private readonly CertificateRepository _db = new CertificateRepository();
        public ActionResult Index()
        {
            var result = _db.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult UpdateCertificate(int id)
        {
            var updateCertificate = _db.Find(x => x.ID == id);
            return View(updateCertificate);
        }

        [HttpPost]
        public ActionResult UpdateCertificate(Certificates certificate)
        {
            var updateCertificate = _db.Find(x => x.ID == certificate.ID);
            updateCertificate.description = certificate.description;
            updateCertificate.date = certificate.date;

            _db.Update(updateCertificate);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(Certificates certificates)
        {
            if (!ModelState.IsValid)
            {
                return View(certificates);
            }
            _db.Add(certificates);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            var deleteCertificate = _db.Find(x => x.ID == id);
            _db.Delete(deleteCertificate);
            return RedirectToAction("Index");
        }
    }
}