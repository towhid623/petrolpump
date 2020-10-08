using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBack.Models.ViewModels
{
    public class VmDistrict
    {
        public int DistrictHeaderId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string DistrictName { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DivisionHeaderId { get; set; }
    }
}