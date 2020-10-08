using Entities.Models;
using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBack.Models.ViewModels;

namespace WebsiteBack.Controllers
{
    [Authorize]
    public class DivisionController : Controller
    {
        #region "Declared objects & Constructor"
        private DatabaseContext db = new DatabaseContext();
        #endregion
        // GET: Division
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(VmDivision vmDivision)
        {
            if (ModelState.IsValid)
            {
                var newrecord = new Division
                {
                    DivisionHeaderId = vmDivision.DivisionHeaderId,
                    DivisionName = vmDivision.DivisionName
                };
                db.Divisions.Add(newrecord);
                db.SaveChanges();
                return RedirectToAction("Add", "Division");
            }
            return View(vmDivision);
        }
        public ActionResult Disable(int id)
        {
            if (db.Districts.Where(o=>o.IsDisabled!=true&&o.DivisionHeaderId==id).Any())
            {
                return Content("");
            }
            else
            {
                var obj = db.Divisions.Find(id);
                obj.IsDisabled = true;
                db.SaveChanges();
                return RedirectToAction("Add", "Division");
            }
        }
        public ActionResult AjaxTable(DatatableServerSideProcessing datatableServerSideProcessing)
        {
            List<VmDivision> results = db.Divisions.Where(a => a.IsDisabled != true).Select(s => new VmDivision
            {
                DivisionHeaderId = s.DivisionHeaderId,
                DivisionName = s.DivisionName
            }).ToList();
            return Json(new
            {
                sEcho = datatableServerSideProcessing.draw,
                iTotalRecords = results.Count(),
                iTotalDisplayRecords = db.Divisions.Count(),
                data = results
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}