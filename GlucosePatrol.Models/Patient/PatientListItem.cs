using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Models
{
    public class PatientListItem
    {
        [Display(Name = "Patient ID")]
        public int PatientId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Weight (Pounds)")]
        public float WeightInPounds { get; set; }
        [Display(Name = "Height (Inches)")]
        public int HeightInInches { get; set; }
        public string Gender { get; set; }
    }
}
