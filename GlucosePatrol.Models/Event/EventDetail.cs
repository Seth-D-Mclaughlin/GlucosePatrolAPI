using GlucosePatrol.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Models
{
    public class EventDetail
    {
        [Display(Name = "Patient ID")]
        public int PatientId { get; set; }
        [Required]
        [Display(Name = "Event ID")]
        public int EventId { get; set; }
        [Display(Name = "Event Type")]
        public EventType TypeOfEvent { get; set; }
        [Display(Name = "Event SubType")]
        public EventSubType? SubTypeOfEvent { get; set; }
        public float? Value { get; set; }
        public UnitType? Unit { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
