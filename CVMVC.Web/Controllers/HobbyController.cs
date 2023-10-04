using System.Web.Mvc;
using CVMVC.Web.Models.Entity;
using CVMVC.Web.Repository;

namespace CVMVC.Web.Controllers
{
    public class HobbyController : Controller
    {
        private readonly HobbyRepository _db = new HobbyRepository();
        
        public ActionResult Index()
        {
            var result = _db.List();
            return View(result);
        }
        [HttpGet]
        public ActionResult UpdateHobby(int id)
        {
            var result = _db.Find(x => x.ID == id);
            return View(result);
        }
        [HttpPost]
        public ActionResult UpdateHobby(Hobbies hobbies)
        {
            var updateHobbies = _db.Find(x => x.ID == hobbies.ID);
            updateHobbies.title1 = hobbies.title1;
            updateHobbies.title2 = hobbies.title2;

            _db.Update(updateHobbies);
            return RedirectToAction("Index");
        }
    }
}