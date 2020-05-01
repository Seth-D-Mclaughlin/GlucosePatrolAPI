using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Models
{
    public class PatientEdit
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int PatientId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float WeightInPounds { get; set; }
        public int HeightInInches { get; set; }
        public string Gender { get; set; }
    }
}
