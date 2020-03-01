using EntityChangeTracking_AspNetCore_3._0.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityChangeTracking_AspNetCore_3._0.Models
{
    public class Example : ITimestamp
    {
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? EditedDateTime { get; set; }
        public string EditedBy { get; set; }

        public int Id { get; set; }
        public string FieldA { get; set; }
        public string FieldB { get; set; }
        public string FieldC { get; set; }
        public string FieldD { get; set; }
    }
}
