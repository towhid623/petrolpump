using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBack.Models.ViewModels
{
    public class DatatableServerSideProcessing
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}