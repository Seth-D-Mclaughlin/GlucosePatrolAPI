using GlucosePatrol.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Models
{
    public class EntryDetail
    {
        public int PatientId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public int EntryId { get; set; }
        [Range(30, 700)]
        public int BloodSugarReading { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
