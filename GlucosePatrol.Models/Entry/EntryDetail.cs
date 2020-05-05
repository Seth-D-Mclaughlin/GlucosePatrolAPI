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
        [Display(Name = "Entry ID")]
        public int EntryId { get; set; }
        [Display(Name = "Patient ID")]
        public int PatientId { get; set; } //from Patient class
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Blood Sugar Reading")]
        [Range(30, 700)]
        public int BloodSugarReading { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
