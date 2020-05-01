using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Data
{
    public class Entry
    {
        [Key]
        public int EntryId { get; set; } // Gives the ability to identify specfic readings

        [Required]
        [Range(30, 700)] //The reading        **Limit the reading to as low as 30 and high as 700**
        public int BloodSugarReading { get; set; } 
        [Required]
        public DateTimeOffset CreatedUtc { get; set; } //When the reading was created
        public DateTimeOffset? ModifiedUtc { get; set; }// When/if the reading was modified

        public int PatientId { get; set; } //Every entry is linked to a patientId 
        [ForeignKey(nameof(PatientId))]    //Patients class has a one to many realtionship with Entry
        public virtual Patient Patient { get; set; } //Gives acesss to Patient properites
    }
}
