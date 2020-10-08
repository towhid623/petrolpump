using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBack.Models.ViewModels
{
    public class VmItem
    {
        public int ItemHeaderId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Unit { get; set; }
        public string Details { get; set; }
    }
}