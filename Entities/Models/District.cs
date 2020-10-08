using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class District:BaseEntity
    {
        [Key]
        public int DistrictHeaderId { get; set; }
        public string DistrictName { get; set; }
        public int DivisionHeaderId { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<Pump> Pump { get; set; }
    }
}
