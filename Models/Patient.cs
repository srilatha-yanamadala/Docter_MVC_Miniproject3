using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MVC_Miniproject3.Models
{
    public class Patient
    {
        public Patient()
        {
           
        }

        public Patient( string patientName, int age, List<Doctor> doctors, DateTime start, DateTime end, string doctorName, string email)
        {
            
            PatientName = patientName;
            Age = age;
            Doctors = doctors;
            Start = start;
            End = end;
            DoctorName = doctorName;
            Email = email;
        }
        [Key]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
       



        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string DoctorName { get; set; }
        public string Email { get; set; }
       

       
    }
}
