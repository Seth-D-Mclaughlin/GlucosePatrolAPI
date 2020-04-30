using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Data
{
    public enum EventType {carbs = 1, insulin, exercise, health }
    public enum EventSubType {fastActing = 1, longActing, light, medium, heavy, illness, stress, highSymptoms, lowSymptoms, cycle, alcohol }
    public enum UnitType { grams = 1, units, minutes}
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        public EventType TypeOfEvent { get; set; }
        public EventSubType? SubTypeOfEvent { get; set; }
        public float? Value { get; set; }
        public UnitType? Unit { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        
        
        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public virtual Patient Patient { get; set; }
    }
}
