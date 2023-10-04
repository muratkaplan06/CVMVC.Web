using System.Web.Mvc;
using CVMVC.Web.Models.Entity;
using CVMVC.Web.Repository;

namespace CVMVC.Web.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        private readonly SkillRepository _db = new SkillRepository();
        public ActionResult Index()
        {
            var result = _db.List();
            return View(result);
        }

       [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skills skills)
        {
            if (!ModelState.IsValid)
            {
                return View(skills);
            }
            _db.Add(skills);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var result = _db.Find(x => x.ID == id);
            _db.Delete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var updateSkill = _db.Find(x => x.ID == id);
            return View(updateSkill);
        }
        [HttpPost]
        public ActionResult UpdateSkill(Skills skills)
        {
            var updateSkill = _db.Find(x => x.ID == skills.ID);
            updateSkill.skill = skills.skill;
            updateSkill.ratio = skills.ratio;

            _db.Update(updateSkill);
            return RedirectToAction("Index");
        }
    }
}