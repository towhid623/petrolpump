using Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities.Models;
using WebsiteBack.Models.ViewModels;

namespace WebsiteBack.Controllers
{
    public class IndexController : Controller
    {
        #region "Declared objects & Constructor"
        private DatabaseContext db = new DatabaseContext();
        #endregion

        // GET: Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search()
        {
            ViewBag.DistrictList = db.Districts.Where(w => w.IsDisabled != true).Select(s => new VmDistrict { DistrictHeaderId = s.DistrictHeaderId, DistrictName = s.DistrictName, DivisionHeaderId = s.DivisionHeaderId });
            ViewBag.DivisionList = db.Divisions.Where(w => w.IsDisabled != true).Select(s => new VmDivision { DivisionHeaderId = s.DivisionHeaderId, DivisionName = s.DivisionName });
            ViewBag.ThanaList = db.Thanas.Where(w => w.IsDisabled != true).Select(s => new VmThana { ThanaHeaderId = s.ThanaHeaderId, ThanaName = s.ThanaName, DistrictHeaderId = s.DistrictHeaderId });
            ViewBag.PumpList = db.Pumps.Where(w=>w.IsDisabled!=true).Select(s => new VmPump { ThanaHeaderId = s.ThanaHeaderId, PumpHeaderId = s.PumpHeaderId, PumpName = s.PumpName });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(VmPumpSearch model)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.PumpId) &&model.PumpId!="null"&& Convert.ToInt32(model.PumpId)>0)
                {
                    
                    return Redirect("/Index/SearchResultItem/"+ Convert.ToInt32(model.PumpId));
                }
                else
                {
                    var obj = new VmPumpSearchObject();
                    List<VmPumpSearchList> vmPumpSearchLists = new List<VmPumpSearchList>();
                    var pumpList = db.Thanas.Where(w => w.ThanaHeaderId == model.ThanaId && w.IsDisabled!=true).FirstOrDefault().Pump.Where(w=>w.IsDisabled!=true);
                    foreach(var i in pumpList)
                    {
                        var pump = new VmPumpSearchList();
                        pump.PumpId = i.PumpHeaderId;
                        pump.PumpName = i.PumpName;
                        pump.LogoUrl = i.LogoImgUrl;
                        pump.Location = i.Location;
                        pump.ContactNumbers = i.MobileNumber;
                        foreach (var j in i.PumpItem)
                        {
                            pump.Items += db.Items.Find(j.ItemHeaderId).ItemName+", ";
                        }
                        if (pump.Items != null)
                        {
                            pump.Items = pump.Items.Remove(pump.Items.Length - 2, 2);
                        }
                        vmPumpSearchLists.Add(pump);
                    }
                    obj.VmPumpSearchList = vmPumpSearchLists;
                    obj.DivisionName = db.Divisions.Find(model.DivisionId).DivisionName;
                    obj.DistrictName = db.Districts.Find(model.DistrictId).DistrictName;
                    obj.ThanaName = db.Thanas.Find(model.ThanaId).ThanaName;
                    TempData["obj"] = obj;

                    return RedirectToAction("SearchResult", "Index");

                }

            }
            return View();
        }
        public ActionResult SearchResult()
        {
            var obj = TempData["obj"];
            if(obj == null)
            {
                return Redirect("/Index/Search/");
            }
            return View(obj);
        }
        public ActionResult SearchResultItem(int id)
        {
            var pump = db.Pumps.Where(w =>w.IsDisabled!=true&& w.PumpHeaderId == id).FirstOrDefault();
            var model = new VmPumpSearchDetails();
            model.ContactNumber = pump.MobileNumber;
            model.Description = pump.Description;
            model.ImgUrl = pump.ImgUrl;
            model.Location = pump.Location;
            model.MapUrl = pump.MapImgUrl;
            model.LogoUrl = pump.LogoImgUrl;
            model.PumpName = pump.PumpName;
            model.Items = new List<VmPumpItem>();
            foreach(var i in pump.PumpItem)
            {
                var itm = new VmPumpItem();
                itm.ItemHeaderId = i.ItemHeaderId;
                itm.ItemName = i.Item.ItemName;
                itm.UnitPrice = i.UnitPrice;
                model.Items.Add(itm);
            }
            return View(model);
        }
    }
}