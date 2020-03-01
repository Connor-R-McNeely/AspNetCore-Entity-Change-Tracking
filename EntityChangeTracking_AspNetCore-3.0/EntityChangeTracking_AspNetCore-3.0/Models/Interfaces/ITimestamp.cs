using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityChangeTracking_AspNetCore_3._0.Models.Interfaces
{
    interface ITimestamp
    {
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? EditedDateTime { get; set; }
        public string EditedBy { get; set; }
    }
}
