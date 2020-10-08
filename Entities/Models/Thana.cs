using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Thana:BaseEntity
    {
        [Key]
        public int ThanaHeaderId { get; set; }
        public string ThanaName { get; set; }
        public int DistrictHeaderId { get; set; }
        public virtual District District { get; set; }
        public virtual ICollection<Pump> Pump { get; set; }
    }
}
