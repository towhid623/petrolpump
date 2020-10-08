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
    public class ItemController : Controller
    {
        #region "Declared objects & Constructor"
        private DatabaseContext db = new DatabaseContext();
        #endregion
        // GET: Item
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
        public ActionResult Add(VmItem vmItem)
        {
            if (ModelState.IsValid)
            {
                var newrecord = new Item
                {
                    ItemHeaderId = vmItem.ItemHeaderId,
                    ItemName = vmItem.ItemName,
                    Unit = vmItem.Unit,
                    Details = vmItem.Details
                };
                db.Items.Add(newrecord);
                db.SaveChanges();
                return RedirectToAction("Add", "Item");
            }
            return View(vmItem);
        }
        public ActionResult Disable(int id)
        {
            var obj = db.Items.Find(id);
            obj.IsDisabled = true;
            db.SaveChanges();
            return RedirectToAction("Add", "Item");
        }
        public ActionResult AjaxTable(DatatableServerSideProcessing datatableServerSideProcessing)
        {
            List<VmItem> results = db.Items.Where(a => a.IsDisabled != true).Select(s => new VmItem
            {
                ItemHeaderId = s.ItemHeaderId,
                ItemName = s.ItemName,
                Unit = s.Unit,
                Details = s.Details
            }).ToList();
            return Json(new
            {
                sEcho = datatableServerSideProcessing.draw,
                iTotalRecords = results.Count(),
                iTotalDisplayRecords = db.Items.Count(),
                data = results
            },
            JsonRequestBehavior.AllowGet);
        }

    }
}