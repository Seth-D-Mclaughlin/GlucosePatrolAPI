using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Data
{
    //We allow our user (patient) to log an event (EventType)
    //With this project centered on diabetes, our events (EventType) were focused on things that can have a direct impact on blood sugar levels
    public enum EventType {carbs = 1, insulin, exercise, health }

    //Below we have subcategories where our user (patient) can provide more specifics for their EventType
    public enum EventSubType {fastActing = 1, longActing, light, medium, heavy, illness, stress, highSymptoms, lowSymptoms, cycle, alcohol }
    
    //Below we have specific units the user (patient) can choose to further describe their event 
    public enum UnitType { grams = 1, units, minutes}
    public class Event
    {
        [Key]
        public int EventId { get; set; } //EventId specifies a certain event 
        [Required]
        public EventType TypeOfEvent { get; set; } 
        public EventSubType? SubTypeOfEvent { get; set; }
        public float? Value { get; set; } //This is where we save the specific value of said Event. Value is nullable because certain events are not quantifiable (stress, cycle, etc.)
        public UnitType? Unit { get; set; } //The type of unit is based on what value the user placed. Units are different depending on the EventType chosen
        [Required]
        public DateTimeOffset CreatedUtc { get; set; } //When the event was created
        public DateTimeOffset? ModifiedUtc { get; set; } //When/if the event was modified
        
        
        public int PatientId { get; set; }  //Every entry is linked to a patientId
        [ForeignKey(nameof(PatientId))]     //Patient class has a one-to-many relationship with Event
        public virtual Patient Patient { get; set; }
    }
}
