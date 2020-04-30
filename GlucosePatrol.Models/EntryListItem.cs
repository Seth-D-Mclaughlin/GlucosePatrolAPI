using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Models
{
    public class EntryListItem
    {
        [Required]
        public int PatientId { get; set; }
        public int EntryId { get; set; }
        
        
        
        public int BloodSugarReading { get; set; }
        
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }


        //string[,] MinMaxAvg = new string[3, 2] { { "Max", " " }, { "Min", " " }, { "Average", "156" } };
         
    }
}
