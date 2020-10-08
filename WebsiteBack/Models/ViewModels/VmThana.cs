using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBack.Models.ViewModels
{
    public class VmThana
    {
        public int ThanaHeaderId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ThanaName { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DistrictHeaderId { get; set; }
    }
}