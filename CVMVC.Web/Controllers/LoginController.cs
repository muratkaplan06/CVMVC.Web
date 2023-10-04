using System.Web.Mvc;
using System.Web.Security;
using CVMVC.Web.Models.Entity;
using CVMVC.Web.Repository;

namespace CVMVC.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly AdminRepository _db = new AdminRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var result = _db.Find(x =>
                x.username == admin.username &&
                x.password == admin.password
            );
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.username,false);
                Session["username"] = result.username.ToString();
                return RedirectToAction("Index","Experience");
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}