using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBack.Models.ViewModels
{
    public class VmPumpSearchDetails
    {
        public int PumpId { get; set; }
        public string PumpName { get; set; }
        public string MapUrl { get; set; }
        public string LogoUrl { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<VmPumpItem> Items { get; set; }
        public string ContactNumber { get; set; }
    }
}