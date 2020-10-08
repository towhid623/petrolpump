using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBack.Models.ViewModels
{
    public class VmPump
    {
        public int PumpHeaderId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string PumpName { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string MapImgUrl { get; set; }
        public string LogoImgUrl { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Required")]
        public int ThanaHeaderId { get; set; }
        public HttpPostedFileBase PumpImage { get; set; }
        public HttpPostedFileBase PumpMapImage { get; set; }
        public HttpPostedFileBase PumpLogoImage { get; set; }
        public List<VmPumpItem> VmPumpItem { get; set; }
    }

    public class VmPumpItem
    {
        public int ItemHeaderId { get; set; }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}