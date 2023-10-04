using System.Web.Mvc;
using CVMVC.Web.Models.Entity;
using CVMVC.Web.Repository;

namespace CVMVC.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminRepository _db = new AdminRepository();
        public ActionResult Index()
        {
            var result = _db.List();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return View(admin);
            }

            var exist=_db.Find(x => x.username == admin.username);
            if (exist != null)
            {
                ViewBag.ErrorMessage = "this username already taken";
                return View("AddAdmin");
            }
            _db.Add(admin);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var deleteAdmin = _db.Find(x => x.ID == id);
            _db.Delete(deleteAdmin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var updateAdmin = _db.Find(x => x.ID == id);
            return View(updateAdmin);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            var updateAdmin = _db.Find(x => x.ID == admin.ID);
            updateAdmin.username = admin.username;
            updateAdmin.password = admin.password;

            _db.Update(updateAdmin);

            return RedirectToAction("Index");
        }
    }
}