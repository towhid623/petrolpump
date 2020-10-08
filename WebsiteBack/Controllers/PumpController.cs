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
    public class PumpController : Controller
    {
        #region "Declared objects & Constructor"
        private DatabaseContext db = new DatabaseContext();
        private string url = "";
        #endregion
        // GET: Pump
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.ItemList = db.Items.Where(s => s.IsDisabled != true).Select(s => new VmSelectList { Id = s.ItemHeaderId, Name = s.ItemName });
            ViewBag.ThanaList = db.Thanas.Where(s => s.IsDisabled != true).Select(s => new VmSelectList { Id = s.ThanaHeaderId, Name = s.ThanaName });
            return View();
        }
        [HttpPost]
        public ActionResult Add(VmPump vmPump)
        {
            if (ModelState.IsValid)
            {
                #region Image Upload
                var uri = Request.Url.Host;
                System.IO.Directory.CreateDirectory(Server.MapPath("~/Images/PumpImage/" + uri));
                System.IO.Directory.CreateDirectory(Server.MapPath("~/Images/PumpLogo/" + uri));
                System.IO.Directory.CreateDirectory(Server.MapPath("~/Images/PumpMap/" + uri));
                string path = "";
                if (vmPump.PumpImage != null)
                {
                    string pic = System.IO.Path.GetFileName(vmPump.PumpImage.FileName);
                    string physicalPath =
                        System.IO.Path.Combine(Server.MapPath("~/Images/PumpImage/" + uri), pic);
                    path = "/Images/PumpImage/" + uri + "/" + pic;
                    vmPump.PumpImage.SaveAs(physicalPath);
                    vmPump.ImgUrl = path;
                }
                if (vmPump.PumpLogoImage != null)
                {
                    string pic = System.IO.Path.GetFileName(vmPump.PumpLogoImage.FileName);
                    string physicalPath =
                        System.IO.Path.Combine(Server.MapPath("~/Images/PumpLogo/" + uri), pic);
                    path = "/Images/PumpLogo/" + uri + "/" + pic;
                    vmPump.PumpLogoImage.SaveAs(physicalPath);
                    vmPump.LogoImgUrl = path;
                }
                if (vmPump.PumpMapImage != null)
                {
                    string pic = System.IO.Path.GetFileName(vmPump.PumpMapImage.FileName);
                    string physicalPath =
                        System.IO.Path.Combine(Server.MapPath("~/Images/PumpMap/" + uri), pic);
                    path = "/Images/PumpMap/" + uri + "/" + pic;
                    vmPump.PumpMapImage.SaveAs(physicalPath);
                    vmPump.MapImgUrl = path;
                }
                #endregion
                var newrecord = new Pump
                {
                    PumpHeaderId = vmPump.PumpHeaderId,
                    PumpName = vmPump.PumpName,
                    Description = vmPump.Description,
                    Location = vmPump.Location,
                    MapImgUrl = vmPump.MapImgUrl,
                    LogoImgUrl=vmPump.LogoImgUrl,
                    ImgUrl=vmPump.ImgUrl,
                    MobileNumber=vmPump.MobileNumber,
                    PhoneNumber=vmPump.PhoneNumber,
                    EmailAddress=vmPump.EmailAddress,
                    ThanaHeaderId = vmPump.ThanaHeaderId
                };
                db.Pumps.Add(newrecord);
                db.SaveChanges();
                var pumpHeaderId = newrecord.PumpHeaderId;
                if (pumpHeaderId > 0)
                {
                    foreach(var i in vmPump.VmPumpItem)
                    {
                        var newPumpItem = new PumpItem();
                        newPumpItem.PumpItemHeaderId = 0;
                        newPumpItem.PumpHeaderId = pumpHeaderId;
                        newPumpItem.ItemHeaderId = i.ItemHeaderId;
                        newPumpItem.UnitPrice = i.UnitPrice;
                        db.PumpItems.Add(newPumpItem);
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("Add", "Pump");
            }
            return View(vmPump);
        }
        public ActionResult Disable(int id)
        {
            var obj = db.Pumps.Find(id);
            obj.IsDisabled = true;
            db.SaveChanges();
            return RedirectToAction("Add", "Pump");
        }
        public ActionResult AjaxTable(DatatableServerSideProcessing datatableServerSideProcessing)
        {
            List<VmPump> results = db.Pumps.Where(a => a.IsDisabled != true).Select(s => new VmPump
            {
                PumpHeaderId = s.PumpHeaderId,
                PumpName = s.PumpName,
                ThanaHeaderId = s.ThanaHeaderId
            }).ToList();
            return Json(new
            {
                sEcho = datatableServerSideProcessing.draw,
                iTotalRecords = results.Count(),
                iTotalDisplayRecords = db.Pumps.Count(),
                data = results
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}