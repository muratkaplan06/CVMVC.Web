using System.Web.Mvc;
using CVMVC.Web.Models.Entity;
using CVMVC.Web.Repository;

namespace CVMVC.Web.Controllers
{
    
    public class ExperienceController : Controller
    {
        private readonly ExperienceRepository _db = new ExperienceRepository();
        [Authorize]
        public ActionResult Index()
        {
            var result = _db.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Experiences experiences)
        {
            if (!ModelState.IsValid)
            {
                return View(experiences);
            }
            _db.Add(experiences);
            return RedirectToAction("Index");
        }

      
        public ActionResult DeleteExperience(int id)
        {
            var deleteExperience = _db.Find(x => x.ID == id);
            _db.Delete(deleteExperience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var updateExperience = _db.Find(x => x.ID == id);
            return View(updateExperience);
        }

        [HttpPost]
        public ActionResult UpdateExperience(Experiences experiences)
        {
            var updateExperience = _db.Find(x => x.ID == experiences.ID);
            updateExperience.title = experiences.title;
            updateExperience.subtitle = experiences.subtitle;
            updateExperience.date = experiences.date;
            updateExperience.description = experiences.description;

            
            _db.Update(updateExperience);
           
            return RedirectToAction("Index");
        }
    }
}