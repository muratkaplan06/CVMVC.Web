using System.Web.Mvc;
using CVMVC.Web.Repository;

namespace CVMVC.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly CommunicationRepository _db = new CommunicationRepository();
        public ActionResult Index()
        {
            var result = _db.List();
            return View(result);
        }
    }
}