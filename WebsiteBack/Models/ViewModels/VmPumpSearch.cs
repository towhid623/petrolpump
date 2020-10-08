using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBack.Models.ViewModels
{
    public class VmPumpSearch
    {
        [Required(ErrorMessage = "Required")]
        public int DivisionId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DistrictId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int ThanaId { get; set; }
        public string PumpId { get; set; }
    }
}