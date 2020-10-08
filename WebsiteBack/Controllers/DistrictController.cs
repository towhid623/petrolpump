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
    public class DistrictController : Controller
    {
        #region "Declared objects & Constructor"
        private DatabaseContext db = new DatabaseContext();
        #endregion
        // GET: District
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.DivisionList = db.Divisions.Where(s=>s.IsDisabled!=true).Select(s=>new VmSelectList { Id=s.DivisionHeaderId,Name=s.DivisionName });
            return View();
        }
        [HttpPost]
        public ActionResult Add(VmDistrict vmDistrict)
        {
            if (ModelState.IsValid)
            {
                var newrecord = new District
                {
                    DistrictHeaderId = vmDistrict.DistrictHeaderId,
                    DistrictName = vmDistrict.DistrictName,
                    DivisionHeaderId=vmDistrict.DivisionHeaderId
                };
                db.Districts.Add(newrecord);
                db.SaveChanges();
                return RedirectToAction("Add", "District");
            }
            return View(vmDistrict);
        }
        public ActionResult Disable(int id)
        {
            if (db.Thanas.Where(o => o.IsDisabled != true && o.DistrictHeaderId == id).Any())
            {
                return Content("");
            }
            else
            {
                var obj = db.Districts.Find(id);
                obj.IsDisabled = true;
                db.SaveChanges();
                return RedirectToAction("Add", "District");
            }
        }
        public ActionResult AjaxTable(DatatableServerSideProcessing datatableServerSideProcessing)
        {
            List<VmDistrict> results = db.Districts.Where(a => a.IsDisabled != true).Select(s => new VmDistrict
            {
                DistrictHeaderId=s.DistrictHeaderId,
                DistrictName=s.DistrictName,
                DivisionHeaderId = s.DivisionHeaderId
            }).ToList();
            return Json(new
            {
                sEcho = datatableServerSideProcessing.draw,
                iTotalRecords = results.Count(),
                iTotalDisplayRecords = db.Districts.Count(),
                data = results
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}