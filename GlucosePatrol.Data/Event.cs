using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Data
{
    //We allow our user (patient) to log and Event (EventType)
    //With this project centered on diabetes our events (EventType) were focused on things that can have a direct impact on Blood Sugar levels
    public enum EventType {carbs = 1, insulin, exercise, health }

    //Below we have Sub Categories that our user (patient) can provide a more specific description for the above events (EventType)
    public enum EventSubType {fastActing = 1, longActing, light, medium, heavy, illness, stress, highSymptoms, lowSymptoms, cycle, alcohol }
    
    //Below we have a specific units the user (patient) can choose to further describe there event 
    public enum UnitType { grams = 1, units, minutes}
    public class Event
    {
        [Key]
        public int EventId { get; set; } //EventId lets us specify a certain event 
        [Required]
        public EventType TypeOfEvent { get; set; }
        public EventSubType? SubTypeOfEvent { get; set; }
        public float? Value { get; set; } //If quantifiable this is where we save the specific value of said Event. We leave nullable because some Health events are not quantifiable.
        public UnitType? Unit { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        
        
        public int PatientId { get; set; }  //Every entry is linked to a patientId
        [ForeignKey(nameof(PatientId))]     //Patients class has a one to many relationship with Entry
        public virtual Patient Patient { get; set; }
    }
}
