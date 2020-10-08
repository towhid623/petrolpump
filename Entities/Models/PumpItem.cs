using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PumpItem:BaseEntity
    {
        [Key]
        public int PumpItemHeaderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int PumpHeaderId { get; set; }
        public int ItemHeaderId { get; set; }
        public virtual Pump Pump { get; set; }
        public virtual Item Item { get; set; }
    }
}
