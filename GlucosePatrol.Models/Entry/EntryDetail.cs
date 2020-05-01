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
        [Required]
        public int EntryId { get; set; }
        public int PatientId { get; set; } //from Patient class
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(30, 700)]
        public int BloodSugarReading { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
