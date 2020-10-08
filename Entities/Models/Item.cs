using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Item:BaseEntity
    {
        [Key]
        public int ItemHeaderId { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public string Details { get; set; }
    }
}
