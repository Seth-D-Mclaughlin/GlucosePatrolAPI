using GlucosePatrol.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Models
{
    public class EventListItem
    {
        [Required]
        public int PatientId { get; set; }
        public int EventId { get; set; }
        public EventType TypeOfEvent { get; set; }
        public EventSubType? SubTypeOfEvent { get; set; }
        public float? Value { get; set; }
        public UnitType? Unit { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
