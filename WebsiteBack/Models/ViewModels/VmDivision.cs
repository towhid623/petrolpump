using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBack.Models.ViewModels
{
    public class VmDivision
    {
        public int DivisionHeaderId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string DivisionName { get; set; }
    }
}