using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MVC_Miniproject3.Models
{
    public class Doctor
    {
        public Doctor()
        {
        }

        public Doctor( string dOctorName, string specliazation, string imageUrl)
        {
            
            DOctorName = dOctorName;
            Specliazation = specliazation;
            ImageUrl = imageUrl;
           
        }
        [Key]
        public int DoctorId { get; set; }
        public string  DOctorName { get; set; }
        public string Specliazation { get; set; }

        public string ImageUrl { get; set; }
        public List<Patient> Patients { get; set; }

    }
}
