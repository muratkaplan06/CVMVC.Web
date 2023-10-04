using System.Web.Mvc;
using CVMVC.Web.Models.Entity;
using CVMVC.Web.Repository;

namespace CVMVC.Web.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        private readonly EducationRepository _db = new EducationRepository();
        public ActionResult Index()
        {
            var result = _db.List();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Educations educations)
        {
            if (!ModelState.IsValid)
            {
                return View(educations);
            }
            _db.Add(educations);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var deleteEducation = _db.Find(x => x.ID == id);
            _db.Delete(deleteEducation);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var updateEducation = _db.Find(x => x.ID == id);
            return View(updateEducation);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Educations educations)
        {
            var updateEducation = _db.Find(x => x.ID ==educations.ID);
            updateEducation.title = educations.title;
            updateEducation.subtitle1 = educations.subtitle1;
            updateEducation.subtitle2 = educations.subtitle2;
            updateEducation.gpa = educations.gpa;
            updateEducation.date = educations.date;
            


            _db.Update(updateEducation);

            return RedirectToAction("Index");
        }
    }
}