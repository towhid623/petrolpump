using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBack.Models.ViewModels
{
    public class VmPumpSearchList
    {
        public int PumpId { get; set; }
        public string PumpName { get; set; }
        public string LogoUrl { get; set; }
        public string Location { get; set; }
        public string Items { get; set; }
        public string ContactNumbers { get; set; }

    }

    public class VmPumpSearchObject
    {
        public List<VmPumpSearchList> VmPumpSearchList { get; set; }
        public string DivisionName { get; set; }
        public string DistrictName { get; set; }
        public string ThanaName { get; set; }
    }
}