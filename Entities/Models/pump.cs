using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Pump:BaseEntity
    {
        [Key]
        public int PumpHeaderId { get; set; }
        public string PumpName { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string MapImgUrl { get; set; }
        public string LogoImgUrl { get; set; }
        public string Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int ThanaHeaderId { get; set; }
        public virtual Thana Thana { get; set; }
        public virtual ICollection<PumpItem> PumpItem { get; set; }
    }
}
