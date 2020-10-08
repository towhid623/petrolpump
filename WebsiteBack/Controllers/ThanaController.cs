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
    public class ThanaController : Controller
    {
        #region "Declared objects & Constructor"
        private DatabaseContext db = new DatabaseContext();
        #endregion
        // GET: Thana
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.DistrictList = db.Districts.Where(s => s.IsDisabled != true).Select(s => new VmSelectList { Id = s.DistrictHeaderId, Name = s.DistrictName });
            return View();
        }
        [HttpPost]
        public ActionResult Add(VmThana vmThana)
        {
            if (ModelState.IsValid)
            {
                var newrecord = new Thana
                {
                    ThanaHeaderId=vmThana.ThanaHeaderId,
                    ThanaName=vmThana.ThanaName,
                    DistrictHeaderId = vmThana.DistrictHeaderId
                };
                db.Thanas.Add(newrecord);
                db.SaveChanges();
                return RedirectToAction("Add", "Thana");
            }
            return View(vmThana);
        }
        public ActionResult Disable(int id)
        {
            if (db.Pumps.Where(o => o.IsDisabled != true && o.ThanaHeaderId == id).Any())
            {
                return Content("");
            }
            else
            {
                var obj = db.Thanas.Find(id);
                obj.IsDisabled = true;
                db.SaveChanges();
                return RedirectToAction("Add", "Thana");
            }
        }
        public ActionResult AjaxTable(DatatableServerSideProcessing datatableServerSideProcessing)
        {
            List<VmThana> results = db.Thanas.Where(a => a.IsDisabled != true).Select(s => new VmThana
            {
                ThanaHeaderId=s.ThanaHeaderId,
                ThanaName=s.ThanaName,
                DistrictHeaderId = s.DistrictHeaderId
            }).ToList();
            return Json(new
            {
                sEcho = datatableServerSideProcessing.draw,
                iTotalRecords = results.Count(),
                iTotalDisplayRecords = db.Thanas.Count(),
                data = results
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}